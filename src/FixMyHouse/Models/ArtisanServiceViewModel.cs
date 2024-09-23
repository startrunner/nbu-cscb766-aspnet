
namespace FixMyHouse.Models;

public record ArtisanServiceViewModel(
    Guid ArtisanId,
    Guid ServiceId,
    string Name,
    string Description,
    string Picture
);