using Challenge.Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence.Configurations
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public static void CategoryModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryId)
                .ValueGeneratedOnAdd();
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        }


    }
    
}
