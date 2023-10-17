using TC.GrupoTrinta.BlogNews.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers();


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

app.UseDocumentation();
app.UseHttpsRedirection();

app.UseCors(CORS_POLICY);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
