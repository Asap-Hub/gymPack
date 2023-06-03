using gym.Application.Extentions;
using gym.Application.Interfaces.Repositories;
using gym.Infrastructure.Persistances.Data.ApplicationDBContext;
using gym.Infrastructure.Persistances.Data.IdentityDbContext;
using gym.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace gym.Infrastructure.Services.Extension
{
    public static class ApplicationServicesRegistration
    {

        //service for adding middlewares
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }



        //service for adding repositories
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericBaseRepository<>), typeof(GenericBaseRepository<>));

            return services;
        }

        //service for adding applications 
        public static IServiceCollection ApplicationDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("localConnection"));
            },ServiceLifetime.Transient
            );

            return services;
        }

        //service for adding applications 
        public static IServiceCollection IdentityDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("identityConnection"));
            
            }, ServiceLifetime.Transient);

             services.AddIdentity<User, UserRole>(options => {

                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;

                //for confirming email before using
                options.SignIn.RequireConfirmedEmail = true;


            }).AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders();


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
