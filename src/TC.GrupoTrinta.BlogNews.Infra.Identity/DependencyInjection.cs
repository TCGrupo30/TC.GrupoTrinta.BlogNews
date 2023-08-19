using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TC.GrupoTrinta.BlogNews.Application.Interfaces;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF;
using TC.GrupoTrinta.BlogNews.Infra.Identity.Context;
using TC.GrupoTrinta.BlogNews.Infra.Identity.Seed;

namespace TC.GrupoTrinta.BlogNews.Infra.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {

        bool useOnlyInMemoryDatabase = false;

        if (configuration["UseOnlyInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]!);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<AppIdentityDbContext>(
                options =>
                {
                    options.UseInMemoryDatabase("InMemory-DSV-Database");
                    options.LogTo(Console.WriteLine, LogLevel.Information);
                });
        }
        else
        {
            services.AddDbContext<AppIdentityDbContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }



        services.AddIdentity<ApplicationUser, IdentityRole<long>>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ManageAllPostsPolicy", policy =>
                policy.RequireRole("Administrator"));

            // Política para criar e editar posts
            options.AddPolicy("CreateEditPostsPolicy", policy =>
                policy.RequireRole("PostEditor"));

            // Política para ler posts
            options.AddPolicy("ReadPostsPolicy", policy =>
                policy.RequireRole("PostReader"));
        });

        services.AddScoped<DataSeeder>();

        services.AddScoped<IAuthenticationService, IdentityService>();

        return services;
    }
}