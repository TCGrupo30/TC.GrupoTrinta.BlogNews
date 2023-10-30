using TC.GrupoTrinta.BlogNews.Api.Configurations;
using TC.GrupoTrinta.BlogNews.Infra.Identity;
using TC.GrupoTrinta.BlogNews.Infra.Identity.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAppConections()
    .AddUseCases()
    .AddAndConfigureControllers();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddIdentity(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var seed = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seed.InitializeAsync();
}

app.UseDocumentation();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
