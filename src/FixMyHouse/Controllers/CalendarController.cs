using FixMyHouse.Data;
using FixMyHouse.Data.Entities;
using FixMyHouse.Models;
using FixMyHouse.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FixMyHouse.Controllers;

public class CalendarController : BaseController
{
    [Authorize]
    [HttpGet("[controller]/{year:int}-{month:int}")]
    public async Task<IActionResult> Index(
        int year, int month,
        [FromServices] UserManager<IdentityUser> userManager,
        [FromServices] ApplicationDbContext db
    )
    {
        if (
            HttpContext.User.Identities.FirstOrDefault(static x => x.IsAuthenticated)
            is not { Name: { } username }
        ) { return Unauthorized(); }

        IdentityUser? user = await userManager.FindByNameAsync(username);
        if (user is null) { return Unauthorized(); }

        DateOnly firstOfMonth = new(year, month, day: 1);

        DateTime from = new(firstOfMonth.AddDays(-10), time: new(ticks: 0), DateTimeKind.Utc);
        DateTime until = new(firstOfMonth.AddDays(40), time: new(ticks: 0), DateTimeKind.Utc);

        IReadOnlyList<ServiceReservationEntity> entities = await
            db
            .ServiceReservations
            .AsNoTracking()
            .Where(x =>
                x.Ref_User == user.Id
                && x.WhenUtc >= from
                && x.WhenUtc <= until
            )
            .Include(x => x.Service)
            .Include(x => x.Artisan)
            .OrderBy(x => x.WhenUtc)
            .ToListAsync();

        Dictionary<DateOnly, List<CalendarReservationViewModel>> reservations = [];
        foreach (ServiceReservationEntity entity in entities)
        {
            var entryModel = entity.ToCalendarViewModel(TimeZoneOffset);
            reservations.GetOrAdd(entryModel.Date, static () => []).Add(entryModel);
        }

        CalendarViewModel model = new(
            FirstOfMonth: firstOfMonth,
            Reservations: reservations.ToDictionary(x => x.Key, x => x.Value.IReadOnly())
        );

        return View(model);
    }
}
