using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.mocks;
using Shop.Data.Repository;
using Shop.Models;

namespace Shop
{
    public class Startup
       
    { 
        private IConfigurationRoot _confString;


        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;

        //}
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv) 
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
          //  services.AddDbContext<AppDBContext>(options => options.UseSqlServer("Server=DESKTOP-0KVSS8M\\SQLEXPRESS; Database=Shop; Trusted_Connection=true"));
            services.AddControllersWithViews();
            services.AddScoped<IAllSites, SiteRepository>();
            services.AddScoped<ISiteCategory, CategoryRepository>();
            services.AddScoped<IAllOrders, OrdersRepository>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddScoped(sp => ShopSite.GetSite(sp));
            services.AddMemoryCache();
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
             
            using (var score = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = score.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObject.Initial(content);
            }
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
           


        }
    }
}
