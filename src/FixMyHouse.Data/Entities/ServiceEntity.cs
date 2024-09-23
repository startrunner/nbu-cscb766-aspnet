namespace FixMyHouse.Data.Entities;

public sealed class ServiceEntity : EntityBase
{
    public required string Name { get; init; }
    public required string Picture { get; init; }
    public required string Description { get; init; }
}