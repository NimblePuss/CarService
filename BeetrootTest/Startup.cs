using System;
using System.IO;
using BeetrooModels.Context;
using BeetrootApi.Extension;
using BeetrootApi.Interfaces;
using BeetrootApi.MapperProvider;
using BeetrootApi.Middleware;
using BeetrootApi.Services;
using BeetrootModels.Context;
using BeetrootRepository.Interfaces;
using BeetrootRepository.MapperProvider;
using BeetrootRepository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace BeetrootApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddScoped<IOrderService, OrderService>();
            services.AddDbContext<BeetrootDbContext>(options => options.UseInMemoryDatabase("BeetrootContext"));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IPersonalInfoService, PersonalInfoService>();
            services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();

            services.AddSingleton(cm => AutoMapperConfig.ConfigureAutoMapper());
            services.AddSingleton<IAutoMapperProvider, AutoMapperProvider>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "BeetrootTest API",
                    Description = "A sample API for testing and prototyping BeetrootTest features"
                });

                c.IncludeXmlComments("BeetrootTest.WebApi.xml");
                c.DescribeAllEnumsAsStrings();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            BeetrootDbInitializer.Seed(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            string folder = Directory.GetCurrentDirectory() + "\\Logs\\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            loggerFactory.AddFile(Path.Combine(folder, $"logger-{DateTime.Today:dd-MM-yyyy}.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            var option = new RewriteOptions().AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
