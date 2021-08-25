using Domain.Entities;
using Domain.Identity;
using Infrastructure.Persistance.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class SiteDbContext : IdentityDbContext<ApplicationUser>
    {
        public SiteDbContext(DbContextOptions<SiteDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<ApplicationUser> users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BlogConfig());
            builder.ApplyConfiguration(new PostConfig());
            builder.ApplyConfiguration(new ApplicationUserConfig());

            base.OnModelCreating(builder);
        }
    }

    //public class SiteNewDbContextFactory : IDesignTimeDbContextFactory<SiteDbContext>
    //{
    //    public SiteDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<SiteDbContext>();
    //        optionsBuilder.UseSqlServer(new ConnectionFactory().GetConnectionString());

    //        return new SiteDbContext(optionsBuilder.Options);
    //    }
    //}
}
