using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TC.GrupoTrinta.BlogNews.Infra.Identity.Context;

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options)
    {
    }
}