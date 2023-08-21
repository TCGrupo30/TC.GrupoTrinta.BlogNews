using Microsoft.OpenApi.Models;

namespace TC.GrupoTrinta.BlogNews.Api.Configurations;

public static class ControllersConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(
        this IServiceCollection services
    )
    {
        services.AddControllers();
        services.AddDocumentation();
        return services;
    }

    private static IServiceCollection AddDocumentation(
        this IServiceCollection services
    )
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tech Challenge", Version = "v1" });
            c.UseAllOfToExtendReferenceSchemas();
        });
        return services;
    }

    public static WebApplication UseDocumentation(
        this WebApplication app
    )
    {
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }
}
