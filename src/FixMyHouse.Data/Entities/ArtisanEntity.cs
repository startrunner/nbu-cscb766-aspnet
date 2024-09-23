using System.ComponentModel.DataAnnotations.Schema;

namespace FixMyHouse.Data.Entities;

public sealed class ArtisanEntity : EntityBase
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Bio { get; init; }
    public required string Picture { get; init; }

    [ForeignKey(nameof(ArtisanServiceEntity.Ref_Artisan))]
    public IReadOnlyList<ArtisanServiceEntity>? Services { get; private set; }
}
