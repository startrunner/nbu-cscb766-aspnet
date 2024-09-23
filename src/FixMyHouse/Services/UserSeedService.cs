using Microsoft.AspNetCore.Identity;

namespace FixMyHouse.Services;

public sealed class UserSeedService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<UserSeedService> _logger;

    public UserSeedService(IServiceScopeFactory serviceScopeFactory, ILogger<UserSeedService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        this._logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using UserManager<IdentityUser> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        //using ApplicationDbContext db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        string email = "default@user.test";

        {//Check if exists
            if (await _userManager.FindByEmailAsync(email) is not null) { return; }//Exists, nothing to do
        }

        {//Create
            IPasswordHasher<IdentityUser> hasher = _userManager.PasswordHasher;

            //We do it like this to bypass password policy
            IdentityUser user = new() { Email = email, UserName = email, Id = email, EmailConfirmed = true };
            user.PasswordHash = hasher.HashPassword(user, "123456");

            await _userManager.CreateAsync(user);
        }

        {//Ensure exists
            var found = await _userManager.FindByEmailAsync(email);
            if (found is null) { _logger.LogError("Failed to create default user"); }
        }
    }
}
