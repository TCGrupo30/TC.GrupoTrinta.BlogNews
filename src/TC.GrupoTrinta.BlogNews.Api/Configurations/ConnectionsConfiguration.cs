using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF.Configurations;

namespace TC.GrupoTrinta.BlogNews.Api.Configurations;

public static class ConnectionsConfiguration
{
    public static IServiceCollection AddAppConections(
        this IServiceCollection services, IConfiguration configuration
    )
    {

        services.AddDbConnection(configuration);

        return services;
    }

    private static IServiceCollection AddDbConnection(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        bool useOnlyInMemoryDatabase = false;

        if (configuration["UseOnlyInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]!);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<BlogNewsDbContext>(
            options => options.UseInMemoryDatabase("InMemory-DSV-Database"));
        }
        else
        {
            services.AddDbContext<BlogNewsDbContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));       
        }


        return services;
    }
}
