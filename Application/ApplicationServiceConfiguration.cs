using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace gym.Application
{
    public static class ApplicationServiceConfiguration
    {
        //service for adding middlewares
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(createUserCommandRequest).Assembly);
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddControllers().AddFluentValidation();
            

            return services;
        }


    }
}
