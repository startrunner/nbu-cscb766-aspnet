using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixMyHouse.Data.Entities;
public sealed class ServiceReservationEntity : EntityBase
{
    public required DateTime WhenUtc
    {
        get => _whenUtc;
        set => _whenUtc = value.Kind switch { DateTimeKind.Utc => value, _ => throw new ArgumentException() };
    }
    private DateTime _whenUtc;

    public required decimal CalculatedPrice { get; init; }

    [ForeignKey(nameof(Artisan))]
    public required Guid Ref_Artisan { get; init; }

    [ForeignKey(nameof(Service))]
    public required Guid Ref_Service { get; init; }

    [ForeignKey(nameof(User))]
    public required string Ref_User { get; init; }

    public required Dictionary<Guid, int> CustomizationWholeNumbers { get; set; } = [];
    public required Dictionary<Guid, Guid> CustomizationGuids { get; set; } = [];
    public required Dictionary<Guid, bool> CustomizationBooleans { get; set; } = [];

    public ArtisanEntity? Artisan { get; private set; }
    public ServiceEntity? Service { get; private set; }
    public IdentityUser? User { get; private set; }
}
