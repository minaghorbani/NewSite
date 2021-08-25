using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configs
{
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(f => f.Id).UseIdentityColumn();

            builder.HasIndex(f => f.Title).IsUnique();

            builder.Property(f => f.Title).HasMaxLength(150).IsRequired();
            
            builder.Property(f => f.Description).HasMaxLength(1000).IsRequired();

            builder.Property(f => f.DateInsert).HasDefaultValue(DateTime.Now).IsRequired();
            
            builder.Property(f => f.TimeStamp).IsRowVersion();

        }
    }
}
