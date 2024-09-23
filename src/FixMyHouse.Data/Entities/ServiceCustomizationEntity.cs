using System.Text.Json.Serialization;

namespace FixMyHouse.Data.Entities;
[JsonPolymorphic]
[JsonDerivedType(typeof(Checkbox), "checkbox")]
[JsonDerivedType(typeof(Options), "options")]
[JsonDerivedType(typeof(WholeNumber), "whole-number")]
public abstract class ServiceCustomizationEntity
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public abstract decimal CalculatePrice();

    public sealed class Checkbox : ServiceCustomizationEntity<bool>
    {
        public required decimal ValueIfTrue { get; init; }
        public override decimal CalculatePrice() => Value ? ValueIfTrue : 0;
    }

    public sealed class WholeNumber : ServiceCustomizationEntity<int>
    {
        public required decimal ValueMultiplier { get; init; }
        public override decimal CalculatePrice() => Value * ValueMultiplier;
    }

    public sealed class Options : ServiceCustomizationEntity<Guid>
    {
        public required IReadOnlyList<Option> AvailableOptions { get; init; }
        public override decimal CalculatePrice() => AvailableOptions.SingleOrDefault(x => x.Id == Value)?.Price ?? 0;
    }

    public sealed class Option
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required decimal Price { get; init; }
    }
}

public abstract class ServiceCustomizationEntity<TValue> : ServiceCustomizationEntity
{
    public required TValue Value { get; set; }
}

