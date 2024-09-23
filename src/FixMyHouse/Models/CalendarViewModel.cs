namespace FixMyHouse.Models;

public record CalendarViewModel(
    DateOnly FirstOfMonth,
    IReadOnlyDictionary<DateOnly, IReadOnlyList<CalendarReservationViewModel>> Reservations
);
