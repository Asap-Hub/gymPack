using gym.Application;
using gym.Infrastructure;
using gym.Infrastructure.Services.Email;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Text;

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

            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Register the console logger
            });

            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });


            //registering mediatR
            services.AddMediatR(typeof(Startup));

            //ApplicationServicesRegistration
            services.ConfigureApplicationServices();
            
            //handing application database
            services.ApplicationDbContextConfiguration(this.Configuration);
 
            //configuration for repositories
            services.AddRepositories();
            //services.AddMediatR(Assembly.GetExecutingAssembly());

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


            services.Configure<SMTPSettings>(this.Configuration.GetSection("SMTP"));

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


            string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
            {
                var secreteKey = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWT:Key"));

                var jwt = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: expiresAt,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(secreteKey),
                        SecurityAlgorithms.HmacSha256Signature));

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }

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

            //app.UseMvc();

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
