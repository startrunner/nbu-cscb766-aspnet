
namespace FixMyHouse.Models;

public record ArtisanViewModel(
    Guid Id,
    string FirstName,
    string FullName,
    string Bio,
    string Picture,
    IReadOnlyList<ArtisanServiceViewModel> Services
);
