using gym.Infrastructure.Services.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Gym
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //handing application database
            services.ApplicationDbContextConfiguration(this.Configuration);
            //ApplicationServicesRegistration
            services.ConfigureApplicationServices();

            //configuration for repositories
            services.AddRepositories();


            //for configuring the identity database
            services.IdentityDbContextConfiguration(this.Configuration);

            //Configure swagger
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "My API",
                    Version = "v1",
                    Description = "API documentation for Your API",
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name",
                        Email = "your.email@example.com",
                        Url = new Uri("https://example.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Your License",
                        Url = new Uri("https://example.com/license")
                    }

                });
            });


            ////dbcontext for handling orders
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{

            //    options.UseSqlServer(configuration.GetConnectionString("localConnection"));
            //}
            //);

            //services.AddScoped<ApplicationDbContext>();


            ////identity context for handling users
            //services.AddIdentity<User, UserRole>()
            //.AddEntityFrameworkStores<IdentityDbContext>()
            //.AddDefaultTokenProviders();

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
