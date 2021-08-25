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
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(f => f.Id).UseHiLo();

            builder.HasIndex(f => f.Title).IsUnique();

            builder.Property(f => f.Title).HasMaxLength(150).IsRequired();
            
            builder.Property(f => f.Description).HasMaxLength(1000).IsRequired();
            
            builder.Property(f => f.Body).IsRequired();
            
            builder.Property(f => f.Thumbnail).HasMaxLength(6000);

            builder.Property(f => f.DateInsert).HasDefaultValue(DateTime.Now).IsRequired();
            
            builder.Property(f => f.TimeStamp).IsRowVersion();

        }
    }
}
