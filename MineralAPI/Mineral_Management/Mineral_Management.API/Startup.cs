using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mineral_Management.Business.Interfaces;
using Mineral_Management.Business.Services;
using Mineral_Management.Data.Models;
using Mineral_Management.Data.Repository;
using AutoMapper;


namespace Mineral_Management.API
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
            services.AddControllers();
            
            services.AddAutoMapper(typeof(Startup));
            
            services.Configure<Mineral_Management_ApiDbSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("Mineral_Management_ApiDbSettings:ConnectionString").Value;
                options.DatabaseName
                    = Configuration.GetSection("Mineral_Management_ApiDbSettings:DatabaseName").Value;
            });

            //Configuration of DI
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
