using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Abstract;
using AnotherGo.Concrete;
using AnotherGo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnotherGo
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
            services.AddMvc();

            services.AddDbContext<GameNightContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GameDatabase")));


            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();


            services.AddCors(options =>
            {
                // allow local host
                options.AddPolicy("LocalTest",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader();
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
