using TC.GrupoTrinta.BlogNews.Api.Configurations;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF.Configurations;
using TC.GrupoTrinta.BlogNews.Infra.Identity;
using TC.GrupoTrinta.BlogNews.Infra.Identity.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAppConections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers();

builder.Services.AddIdentity(builder.Configuration);
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

await using (var scope = app.Services.CreateAsyncScope())
{
    var seed = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seed.InitializeAsync();
}

app.UseDocumentation();
app.UseHttpsRedirection();

app.UseCors(CORS_POLICY);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
