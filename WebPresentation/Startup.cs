using Application.BlogApplication;
using Application.BlogApplication.Command.Create;
//using Application.BlogApplication.Queries.FindById;
//using Application.BlogApplication.Queries.GetAll;
using Application.Common;
using Autofac;
using Domain.Identity;
using Helpers.Email;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebPresentation.Models;
//using WebPresentation.Data;

namespace WebPresentation
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

            services.AddDbContext<SiteDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SiteDbContext>()
            .AddDefaultTokenProviders()
           .AddDefaultUI();


            //services.AddDbContext<SiteDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //   .AddEntityFrameworkStores<SiteDbContext>()
            //   .AddDefaultTokenProviders()
            //   .AddDefaultUI();
            
            services.AddAuthentication(option =>
            {
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuer = Configuration["BearerTokens:Issuer"],
                        ValidateIssuer = false,
                        ValidAudience = Configuration["BearerTokens:Audience"],
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["BearerTokens:Key"])),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.Configure<IdentityOptions>(option=> { 
            
            });

            services.Configure<CookieAuthenticationOptions>(option =>
            {
                option.ExpireTimeSpan = TimeSpan.FromDays(1);
                option.Cookie.Expiration = TimeSpan.FromDays(2);
            });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("RequireAdminRole", policy => policy.RequireRole("admin"));
                option.AddPolicy("TehranOnly", policy => policy.RequireClaim("City", "Tehran"));
                //option.AddPolicy("Adult", policy => {
                //    policy.Requirements.Add(new MinAgeRequirement(20))
                //});
            });
            services.AddMvc().AddRazorPagesOptions(option=> {
                option.Conventions.AuthorizeAreaFolder("User", "/");
                option.Conventions.AuthorizeAreaFolder("Admin", "/", "RequireAdminRole");
            });

            services.AddHttpContextAccessor();

            //var serviceProvider = services.BuildServiceProvider();
            //var logger = serviceProvider.GetService<ILogger<BlogService>>();
            //services.AddSingleton(typeof(ILogger), logger);


            services.AddTransient<IEmailSender, EmailSender>();
            services.AddAutoMapper(typeof(Mappers).GetTypeInfo().Assembly);



            //services.AddMediatR(typeof(BlogCreateCommand).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(FindBlogsByIdQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(GetAllBlogsQuery).GetTypeInfo().Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<BlogCreateCommand, int>), typeof(BlogCreateValidationBehavior<BlogCreateCommand, int>));
            //services.AddTransient<IBlogRepository, BlogRepository>();

            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddControllersWithViews();
            
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

                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private void ConfigureDatabaseOptions(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), ConfigureSqlServerDatabaseOptions);
        }

        private void ConfigureSqlServerDatabaseOptions(SqlServerDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(SiteDbContext).Namespace);
        }
      

    }
}
