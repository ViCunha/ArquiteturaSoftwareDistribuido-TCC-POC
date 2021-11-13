using FluentValidation.AspNetCore;
using Identity.Application.Configure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Identity.WebAPI
{
    public class Startup
    {
        //
        public IConfiguration Configuration { get; }
        //
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServiceCollection(Configuration);

            services.AddAuthentication
                     (
                        options =>
                        {
                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            //options.DefaultChallengeScheme = 
                        }

                    );
                     
                     //.AddJwtBearer(options =>
                     //       {
                     //           options.TokenValidationParameters = new TokenValidationParameters
                     //           {
                     //               ValidateIssuer = true,
                     //               ValidateAudience = true,
                     //               ValidateLifetime = true,
                     //               ValidateIssuerSigningKey = true,

                     //               ValidIssuer = Configuration["Jwt:Issuer"],
                     //               ValidAudience = Configuration["Jwt:Audience"],
                     //               IssuerSigningKey = new SymmetricSecurityKey
                     //             (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                     //           };
                     //       });

            services.AddApiVersioning
                (
                    options => 
                    {
                        options.DefaultApiVersion = new ApiVersion(1, 0);
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.ReportApiVersions = true;
                    }
                );

            services.AddVersionedApiExplorer
                (
                    options =>
                    {
                        options.GroupNameFormat = "'v'VVV";
                        options.SubstituteApiVersionInUrl = true;
                    }
                );

            services.AddControllers()
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
                
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity.WebAPI", Version = "v1" });

                    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //c.IncludeXmlComments(xmlPath);

            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
