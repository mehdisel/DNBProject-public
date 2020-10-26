using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBProject.BLL.ProductManagement;
using DNBProject.BLL.ShoppingCartManagement;
using DNBProject.BLL.UserManagement;
using DNBProject.DAL.DatabaseContext;
using DNBProject.DAL.EF.DalClasses;
using DNBProject.DAL.EF.Interfaces;
using DNBProject.Entities.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DNBProject.UI
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
      
            services.AddTransient<IProductService, ProductManager>();
            services.AddTransient<IProductDal, ProductDal>();
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<IShoppingCartService, ShoppingCartManager>();
            services.AddTransient<IShoppingCartDal, ShoppingCartDal>();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddSession();
            services.AddControllersWithViews();

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
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
