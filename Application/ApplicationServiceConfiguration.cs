using FluentValidation.AspNetCore;
using gym.Application.Commands.IdentityCommand.Requests;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            services.AddControllers().AddFluentValidation();
            

            return services;
        }


    }
}
