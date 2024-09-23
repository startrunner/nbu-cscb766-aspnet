using Microsoft.EntityFrameworkCore;

namespace FixMyHouse.Data.Entities;

[PrimaryKey(nameof(Id))]
public abstract class EntityBase
{
    public required Guid Id { get; init; }
}
