using TC.GrupoTrinta.BlogNews.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
    .AddAppConections()
    .AddUseCases()
    .AddAndConfigureControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
