namespace FixMyHouse.Models;

public record CalendarReservationViewModel(
    DateOnly Date,
    TimeOnly Time,
    Guid ReservationId,
    string ServiceName,
    string ArtisanFirstName
);
