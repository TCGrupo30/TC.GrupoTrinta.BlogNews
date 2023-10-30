using TC.GrupoTrinta.BlogNews.Application.Interfaces;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;
using TC.GrupoTrinta.BlogNews.Domain.Repository;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF.Repositories;

namespace TC.GrupoTrinta.BlogNews.Api.Configurations;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(
        this IServiceCollection services
    )
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblyContaining<CreateNews>();
        });

        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(
            this IServiceCollection services
        )
    {
        services.AddTransient<INewsRepository, NewsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
