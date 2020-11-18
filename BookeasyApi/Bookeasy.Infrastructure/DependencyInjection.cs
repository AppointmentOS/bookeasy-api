using System;
using System.Text;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Bookeasy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,  IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddScoped<IUserManager, UserManagerService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddScoped<IAuthenticationTokenGenerator>(provider =>
            {
                return new JwtAuthenticationTokenGenerator(configuration["Jwt:Key"], configuration["Jwt:Issuer"]);
            });
            // configure JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            
            return services;
        }
    }
}