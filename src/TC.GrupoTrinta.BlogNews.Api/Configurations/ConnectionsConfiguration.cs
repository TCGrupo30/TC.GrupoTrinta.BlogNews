using Microsoft.EntityFrameworkCore;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF;

namespace TC.GrupoTrinta.BlogNews.Api.Configurations;

public static class ConnectionsConfiguration
{
    public static IServiceCollection AddAppConections(
        this IServiceCollection services
    )
    {
        services.AddDbConnection();
        return services;
    }

    private static IServiceCollection AddDbConnection(
        this IServiceCollection services
    )
    {
        services.AddDbContext<BlogNewsDbContext>(
            options => options.UseInMemoryDatabase("InMemory-DSV-Database")
        );
        return services;
    }
}
