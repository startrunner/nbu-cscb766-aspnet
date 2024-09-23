using System.Text.Json.Serialization;

namespace FixMyHouse.Models;

[JsonPolymorphic]
[JsonDerivedType(typeof(Checkbox), "checkbox")]
[JsonDerivedType(typeof(Options), "options")]
[JsonDerivedType(typeof(WholeNumber), "whole-number")]
public abstract class ServiceCustomizationViewModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string? Description { get; init; }

    public sealed class Checkbox : ServiceCustomizationViewModel
    {
        //public required bool Value { get; set; }
        public required decimal PriceIfChecked { get; init; }
    }

    public sealed class WholeNumber : ServiceCustomizationViewModel
    {
        //public required decimal Value { get; set; }
    }

    public sealed class Options : ServiceCustomizationViewModel
    {
        //public required Guid Value { get; set; }
        public required IReadOnlyList<Option> AvailableOptions { get; init; }
    }

    public sealed class Option
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required decimal Price { get; init; }
    }
}

