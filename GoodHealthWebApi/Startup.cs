using System;
using System.Globalization;
using System.IO;
using GoodHealth.CroosCuttimg.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using AutoMapper;
using GoodHealth.CrossCutting.Usuario.Mappings;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace GoodHealthWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterServices(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.RegisterRepositoryDependencies(Configuration["ConnectionStrings:DefaultConnection"]);

            var profiles = new List<Profile> {
                new UsuarioDomainToDto()
            };

            services.Configure(Configuration, profiles);

            services.AddCors(o =>
                o.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .AllowAnyOrigin();
                }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            

            ConfigureSwagger(services);


        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            var pathToDoc = Configuration["Swagger:FileName"];
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Good Health 1.0",
                        Version = "v1",
                        Description = "",
                        TermsOfService = "None"
                    }
                 );

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, pathToDoc);
                options.IncludeXmlComments(filePath);
                options.DescribeAllEnumsAsStrings();
                options.CustomSchemaIds(x => x.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureDefaultRoute(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger(c => c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value));

            app.UseSwaggerUI(c => c.SwaggerEndpoint(Configuration["Swagger:Url"], "V1 Docs"));
        }

        private static void ConfigureDefaultRoute(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("/", context =>
            {
                return context.Response.WriteAsync("Api running.");
            });

            app.UseRouter(routeBuilder.Build());
        }
    }
}
