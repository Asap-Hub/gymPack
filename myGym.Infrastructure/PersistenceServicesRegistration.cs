using FluentValidation;
using FluentValidation.AspNetCore;
using gym.Application.Commands.IdentityCommand.Queries;
using gym.Application.Commands.IdentityCommand.Requests;
using gym.Application.Commands.user.Validations;
using gym.Application.DTOs.Identity;
using gym.Application.Extentions.Exceptions;
using gym.Application.Extentions.IdentityExtension;
using gym.Application.Interfaces;
using gym.Application.Interfaces.Services;
using gym.Infrastructure.Persistances.ApplicationDBContext;
using gym.Infrastructure.Persistances.Repositories;
using gym.Infrastructure.Services.Email; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System; 
using System.Reflection;
using System.Text;

namespace gym.Infrastructure
{
    public static class PersistenceServicesRegistration
    {

      

        //service for adding repositories
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericBaseRepository<>), typeof(GenericBaseRepository<>));
            services.AddTransient<IEmailService, EmailService>(); 
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            //registring fluent validation
            services.AddTransient<IValidator<CreateUserDto>, CreateUserValidation>();

            return services;
        }

        //service for handling customize tables 
        public static IServiceCollection ApplicationDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("localConnection"));
            }, ServiceLifetime.Transient
            );

            return services;
        }

        //service for adding identity tables 
        public static IServiceCollection IdentityDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("localConnection"));

            }, ServiceLifetime.Transient);

            services.AddIdentity<User, UserRole>(options =>
            {

                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;

                //for confirming email before using
                options.SignIn.RequireConfirmedEmail = true;


            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            //for handling Authentication
            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                };
            });

            //for handling authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireClaim("Admin"));
            });

            return services;
        }


    }
}
