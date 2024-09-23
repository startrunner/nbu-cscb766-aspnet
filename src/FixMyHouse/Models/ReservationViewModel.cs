namespace FixMyHouse.Models;

public record ReservationViewModel
{
    public required Guid? ReservationId { get; init; }
    public required Guid ArtisanId { get; init; }
    public required Guid ServiceId { get; init; }

    public required string ServiceName { get; init; } = "?";
    public required string ArtisanFullName { get; init; } = "?";

    public DateTime WhenLocal { get; set; }

    public required IReadOnlyList<ServiceCustomizationViewModel> CustomizationDefaults { get; init; } = [];
    public required Dictionary<Guid, int> CustomizationWholeNumbers { get; set; } = [];
    public required Dictionary<Guid, Guid> CustomizationGuids { get; set; } = [];
    public required Dictionary<Guid, bool> CustomizationBooleans { get; set; } = [];
}
