using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using TC.GrupoTrinta.BlogNews.Api.Configurations;
using TC.GrupoTrinta.BlogNews.Domain.SeedWork;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddAppConections(builder.Configuration)
            .AddUseCases()
            .AddAndConfigureControllers();

        builder.Services.AddProblemDetails(cfg =>
        {
            cfg.IncludeExceptionDetails = (ctx, env) => false;

            cfg.Map<DomainExceptionValidation>(exc => new ProblemDetails()
            {
                Title = exc.Message,
                Detail = exc.Message,
                Status = StatusCodes.Status422UnprocessableEntity,
                Type = "https://httpstatuses.io/422"
            });

        });

        builder.Services.AddApplicationInsightsTelemetry();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        const string CORS_POLICY = "CorsPolicy";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: CORS_POLICY,
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin();
                    corsPolicyBuilder.AllowAnyMethod();
                    corsPolicyBuilder.AllowAnyHeader();
                });
        });

        var app = builder.Build();

        app.UseProblemDetails();

        app.UseDocumentation();
        app.UseHttpsRedirection();

        app.UseCors(CORS_POLICY);
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}