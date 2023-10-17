using Microsoft.AspNetCore.Identity;

namespace TC.GrupoTrinta.BlogNews.Infra.Identity.Seed;

public class DataSeeder
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<long>> _roleManager;

    public DataSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<long>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        var roles = new[] { "Administrator", "PostEditor", "PostReader" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole<long>(role));
            }
        }
        
        var adminUser = new ApplicationUser
        {
            FirstName = "Administrador",
            LastName = "Do blog",
            UserName = "admin@grupo30.fiap.com.br",
            Email = "admin@grupo30.fiap.com.br"
        };
        await CreateUserIfNotExists(adminUser, "Senha@123", "Administrator");

        var postEditorUser = new ApplicationUser
        {
            FirstName = "Redator",
            LastName = "Do blog",
            UserName = "redator@grupo30.fiap.com.br",
            Email = "redator@grupo30.fiap.com.br"
        };
        await CreateUserIfNotExists(postEditorUser, "Senha@123", "PostEditor");

        var postReaderUser = new ApplicationUser
        {
            FirstName = "Leitor",
            LastName = "Do blog",
            UserName = "leitor@grupo30.fiap.com.br",
            Email = "leitor@grupo30.fiap.com.br"
        };
        await CreateUserIfNotExists(postReaderUser, "Senha@123", "PostReader");
    }
    private async Task CreateUserIfNotExists(ApplicationUser user, string password, string role)
    {
        var existingUser = await _userManager.FindByNameAsync(user.UserName!);

        if (existingUser == null)
        {
            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}