using Challenge.Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public static void RatingModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Rating>()
                .Property(p => p.RatingId)
                .ValueGeneratedOnAdd();
        }

        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(m => m.RateOption).IsRequired();
            builder.Property(m => m.MovieId).IsRequired();
            builder.Property(m => m.RateUser).IsRequired();

        }
    }
}
