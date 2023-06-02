using gym.Infrastructure.Persistances.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Infrastructure.Service
{
    public static class UsersDbConfiguration
    {
       public static IServiceCollection GymUserDbConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("localConnection"));
            }
            );

            return services;
        }
    }
}
