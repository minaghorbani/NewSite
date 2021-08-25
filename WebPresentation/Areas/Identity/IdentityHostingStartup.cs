using System;
using Domain.Identity;
using Infrastructure;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WebPresentation.Areas.Identity.IdentityHostingStartup))]
namespace WebPresentation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<SiteDbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("SiteDbContextConnection")));

                services.AddDbContext<SiteDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SiteDbContext>()
                .AddDefaultTokenProviders()
               .AddDefaultUI();
            });
        }
    }
}