using FixMyHouse.Data.Entities;
using FixMyHouse.Models;

namespace FixMyHouse.Utils;

internal static class ModelMapping
{
    public static ArtisanViewModel ToViewModel(this ArtisanEntity entity) => new(
        entity.Id,
        FirstName: entity.FirstName,
        FullName: $"{entity.FirstName} {entity.LastName}",
        Bio: entity.Bio,
        Picture: entity.Picture,
        Services: (entity.Services ?? []).Select(ToViewModel).ToList()
    );

    public static ArtisanServiceViewModel ToViewModel(this ArtisanServiceEntity entity) => new(
        ArtisanId: entity.Ref_Artisan,
        ServiceId: entity.Ref_Service,
        Name: entity.Service?.Name ?? "?",
        Picture: entity.Service?.Picture ?? "?",
        Description: entity.Service?.Description ?? "?"
    );

    public static CalendarReservationViewModel ToCalendarViewModel(this ServiceReservationEntity entity, TimeSpan timeZoneOffset)
    {
        if (entity is not { Service: { }, Artisan: { } }) { throw new Exception("Entity not full"); }
        DateTimeOffset whenUtc = new(entity.WhenUtc, offset: TimeSpan.Zero);
        DateTimeOffset whenLocal = whenUtc.ToOffset(timeZoneOffset);
        DateOnly date = new(whenLocal.Year, whenLocal.Month, whenLocal.Day);
        TimeOnly time = new(whenLocal.TimeOfDay.Ticks);
        return new(
                Date: date, Time: time,
                ReservationId: entity.Id,
                ServiceName: entity.Service.Name,
                ArtisanFirstName: entity.Artisan.FirstName
        );
    }

    public static ServiceCustomizationViewModel ToViewModel(this ServiceCustomizationEntity entity) => entity switch {
        ServiceCustomizationEntity.Checkbox cb => new ServiceCustomizationViewModel.Checkbox {
            Id = cb.Id,
            Name = cb.Name,
            Description = cb.Description,
            PriceIfChecked = cb.ValueIfTrue,
            //Value = cb.Value
        },
        ServiceCustomizationEntity.WholeNumber wn => new ServiceCustomizationViewModel.WholeNumber {
            Id = wn.Id,
            Description = wn.Description,
            Name = wn.Name,
            //Value = wn.Value,
        },
        ServiceCustomizationEntity.Options opt => new ServiceCustomizationViewModel.Options {
            Id = opt.Id,
            Description = opt.Description,
            Name = opt.Name,
            //Value = opt.Value,
            AvailableOptions =
                opt.AvailableOptions
                .Select(x => new ServiceCustomizationViewModel.Option { Id = x.Id, Name = x.Name, Price = x.Price })
                .ToList(),
        },
        _ => throw new NotImplementedException(),
    };
}
