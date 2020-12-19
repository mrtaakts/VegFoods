using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Services;
using VegFoods.Core;
using VegFoods.Data;
using VegFoods.Data.UnitOfWork;
using VegFoods.Services.Services;
using VegFoods.Data.Repositories;
using VegFoods.Core.UnitOfWork;
using AutoMapper;

namespace VegFoods.Api
{

    // Identity login logout 
    // CRUD food category vs.
    // UnitOfWork açýkla
    // Dockerize , heroku
    // Generic repo
    // azure 
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddControllers();
            services.AddMvc();
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IingredientService, IngredientService > ();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DevConnection").ToString(), o =>
                {
                    o.MigrationsAssembly("VegFoods.Data");
                });

            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

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
