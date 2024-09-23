using FixMyHouse.Data;
using FixMyHouse.Data.Entities;
using FixMyHouse.Models;
using FixMyHouse.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FixMyHouse.Controllers;

public class ServicesController : BaseController
{
    [StringSyntax("Route")]
    private const string ReserveRoute = "[controller]/Reserve/{artisanId:guid}/{serviceId:guid}";

    private readonly ApplicationDbContext _db;

    public ServicesController(ApplicationDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    [Authorize]
    [HttpGet("[controller]/EditReservation/{reservationId:guid}")]
    public async Task<IActionResult> EditReservation(Guid reservationId)
    {
        ServiceReservationEntity? entity = await
            _db.ServiceReservations
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == reservationId);
        if (entity is null) { return NotFound(); }

        return await ReserveInternal(entity.Ref_Artisan, entity.Ref_Service, entity.Id);
    }


    [Authorize]
    [HttpGet(ReserveRoute)]
    public async Task<IActionResult> Reserve(Guid artisanId, Guid serviceId)
    {
        return await ReserveInternal(artisanId, serviceId, existingReservationId: null);
    }

    private async Task<IActionResult> ReserveInternal(Guid artisanId, Guid serviceId, Guid? existingReservationId)
    {
        var artisanService =
            await _db
            .ArtisanServices
            .AsNoTracking()
            .Where(x => x.Ref_Artisan == artisanId && x.Ref_Service == serviceId)
            .Include(x => x.Artisan)
            .Include(x => x.Service)
            .SingleOrDefaultAsync();

        if (artisanService is not { Service: { }, Artisan: { } }) { return NotFound(); }

        ServiceReservationEntity? existingEntity =
            existingReservationId == null ? null :
            await _db.ServiceReservations.AsNoTracking().SingleOrDefaultAsync(x => x.Id == existingReservationId);

        DateTime now = DateTime.Now;

        ReservationViewModel model = new()
        {
            ReservationId = existingEntity?.Id,
            ArtisanId = artisanService.Artisan.Id,
            ServiceId = artisanService.Service.Id,
            WhenLocal = existingEntity switch
            {
                null => new DateTime(now.Year, now.Month, now.Day, 12, 0, 0, DateTimeKind.Unspecified).AddDays(Random.Shared.Next(10)),
                { } => new DateTime(existingEntity.WhenUtc.Ticks, DateTimeKind.Unspecified) + TimeZoneOffset,
            },
            ServiceName = artisanService.Service.Name,
            ArtisanFullName = $"{artisanService.Artisan.FirstName} {artisanService.Artisan.LastName}",

            CustomizationBooleans =
                (existingEntity?.CustomizationBooleans)
                ?? artisanService.CustomizationDefaults.OfType<ServiceCustomizationEntity<bool>>().ToDictionary(static x => x.Id, static x => x.Value),
            CustomizationWholeNumbers =
                (existingEntity?.CustomizationWholeNumbers)
                ?? artisanService.CustomizationDefaults.OfType<ServiceCustomizationEntity<int>>().ToDictionary(static x => x.Id, static x => x.Value),
            CustomizationGuids =
                (existingEntity?.CustomizationGuids)
                ?? artisanService.CustomizationDefaults.OfType<ServiceCustomizationEntity<Guid>>().ToDictionary(static x => x.Id, static x => x.Value),

            CustomizationDefaults = artisanService.CustomizationDefaults.Select(static x => x.ToViewModel()).ToList(),
        };

        return View(nameof(Reserve), model);
    }

    [Authorize]
    public async Task<IActionResult> PostReservation(
        [FromForm] ReservationViewModel model,
        [FromServices] UserManager<IdentityUser> userManager
    )
    {
        if (
            HttpContext.User.Identities.FirstOrDefault(static x => x.IsAuthenticated)
            is not { Name: { } username }
        ) { return Unauthorized(); }

        IdentityUser? user = await userManager.FindByNameAsync(username);
        if (user is null) { return Unauthorized(); }

        var entity =
            await _db
            .ArtisanServices
            .AsNoTracking()
            .Where(x => x.Ref_Artisan == model.ArtisanId && x.Ref_Service == model.ServiceId)
            .SingleOrDefaultAsync();
        if (entity is not { }) { return NotFound(); }

        IReadOnlyList<ServiceCustomizationEntity> customizations = entity.CustomizationDefaults;
        ApplyCustomizations(customizations, model);
        decimal calculatedPrice = customizations.Sum(static x => x.CalculatePrice());

        string userId = user.Id;

        DateTime whenUtc = new DateTimeOffset(model.WhenLocal, TimeZoneOffset).UtcDateTime;
        if (model.ReservationId is { } reservationId)
        {
            ServiceReservationEntity? existing = await _db.ServiceReservations.SingleOrDefaultAsync(x => x.Id == reservationId);
            if (existing is null) { return NotFound(); }
            existing.CustomizationBooleans = model.CustomizationBooleans;
            existing.CustomizationGuids = model.CustomizationGuids;
            existing.CustomizationWholeNumbers = model.CustomizationWholeNumbers;
            existing.WhenUtc = whenUtc;
        }
        else
        {
            _db.ServiceReservations.Add(new()
            {
                Id = Guid.NewGuid(),
                CalculatedPrice = calculatedPrice,
                Ref_Artisan = entity.Ref_Artisan,
                Ref_Service = entity.Ref_Service,
                Ref_User = userId,
                WhenUtc = whenUtc,
                CustomizationBooleans = model.CustomizationBooleans,
                CustomizationGuids = model.CustomizationGuids,
                CustomizationWholeNumbers = model.CustomizationWholeNumbers,
            });
        }

        await _db.SaveChangesAsync();

        return RedirectToAction(
            controllerName: "Calendar",
            actionName: nameof(CalendarController.Index),
            routeValues: new { year = whenUtc.Year, month = whenUtc.Month }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Calculate([FromForm] ReservationViewModel model)
    {
        var entity =
            await _db
            .ArtisanServices
            .AsNoTracking()
            .Where(x => x.Ref_Artisan == model.ArtisanId && x.Ref_Service == model.ServiceId)
            .Include(x => x.Artisan)
            .Include(x => x.Service)
            .SingleOrDefaultAsync();

        if (entity is not { Service: { }, Artisan: { } }) { return NotFound(); }

        IReadOnlyList<ServiceCustomizationEntity> customizations = entity.CustomizationDefaults;
        ApplyCustomizations(customizations, model);
        decimal calculatedPrice = customizations.Sum(static x => x.CalculatePrice());

        return Json(calculatedPrice);
    }

    private static void ApplyCustomizations(IReadOnlyList<ServiceCustomizationEntity> customizationsTarget, ReservationViewModel modelSource)
    {
        customizationsTarget
            .OfType<ServiceCustomizationEntity<bool>>()
            .ForEach(x => x.Value = modelSource.CustomizationBooleans.GetValueOrNull(x.Id) ?? x.Value);

        customizationsTarget
            .OfType<ServiceCustomizationEntity<int>>()
            .ForEach(x => x.Value = modelSource.CustomizationWholeNumbers.GetValueOrNull(x.Id) ?? x.Value);

        customizationsTarget
            .OfType<ServiceCustomizationEntity<Guid>>()
            .ForEach(x => x.Value = modelSource.CustomizationGuids.GetValueOrNull(x.Id) ?? x.Value);
    }
}
