using FixMyHouse.Data;
using FixMyHouse.Models;
using FixMyHouse.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FixMyHouse.Controllers;

public sealed class ArtisansController : Controller
{
    private readonly ApplicationDbContext _db;

    public ArtisansController(ApplicationDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<IActionResult> List()
    {
        var entities = await _db.Artisans.AsNoTracking().ToListAsync();
        var models = entities.Select(static x => x.ToViewModel()).ToList();
        return View(models);
    }

    [Route("[controller]/{id:guid}")]
    public async Task<IActionResult> View(Guid id)
    {
        var entity = await
            _db.Artisans
            .AsNoTracking()
            .Include(x => x.Services!).ThenInclude(x => x.Service)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (entity is null) { return NotFound(); }
        var model = entity.ToViewModel();
        return View(model);
    }
}
