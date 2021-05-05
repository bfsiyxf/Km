using Km.Data.IRepository;
using Km.Data.Model;
using Km.Data.Repository;
using Km.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Km.Web
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
            services.AddDbContext<KmDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();



            // Identity
            //services.AddIdentity<User, Role>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;
            //    options.User.RequireUniqueEmail = true;
            //})
            //.AddEntityFrameworkStores<KmDbContext>()
            //.AddDefaultTokenProviders();
            //services.AddIdentity<IdentityUser, IdentityRole>(option =>
            //{
            //    //    //option.Password.RequireDigit = false;
            //    //    //option.Password.RequiredLength = 2;
            //    //    //option.Password.RequireLowercase = false;
            //    //    //option.User.RequireUniqueEmail = false;
            //});
            //services.AddIdentity<User, Role>(option =>
            //{
            //    //option.Password.RequireDigit = false;
            //    //option.Password.RequiredLength = 2;
            //    //option.Password.RequireLowercase = false;
            //    //option.User.RequireUniqueEmail = false;
            //});
            //services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<KmDbContext>();
            services.AddControllersWithViews();

            //services.AddSingleton<ITagRepository, TagRepository>();
            //services.AddSingleton<IArticleRepository, ArticleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
