using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixMyHouse.Data.Entities;

[PrimaryKey(nameof(Ref_Artisan), nameof(Ref_Service))]
public sealed class ArtisanServiceEntity
{
    [ForeignKey(nameof(Artisan))]
    public required Guid Ref_Artisan { get; init; }

    [ForeignKey(nameof(Service))]
    public required Guid Ref_Service { get; init; }

    public ArtisanEntity? Artisan { get; private set; }
    public ServiceEntity? Service { get; private set; }

    //JSON field, see OnModelCreating
    public required ImmutableList<ServiceCustomizationEntity> CustomizationDefaults { get; init; }
}
