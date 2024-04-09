
using System.Text;
using BookStore.application.DTO.JWT;
using BookStore.application.Interface;
using BookStore.domain.Models;
using BookStore.Identity.Data;
using BookStore.Identity.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthApplicationDbContext>(opt =>
                opt.UseSqlServer(
                    configuration.GetConnectionString("AuthDBDefaultConnection")));

            // Add Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add UserManager
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<IAuthService, AuthService>();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });

            return services;
        }
    }
}