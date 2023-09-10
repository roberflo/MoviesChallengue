using Challenge.Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Challenge.Movies.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public static void MovieModelCreating(ModelBuilder modelBuilder) {

           

            modelBuilder.Entity<Movie>()
                .Property(p => p.MovieId)
                .ValueGeneratedOnAdd();
        }
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.MovieId).IsRequired();
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m=>m.Synopsis).IsRequired().HasMaxLength(500);
            builder.Property(m => m.ReleaseDate).IsRequired().HasConversion<DateTime>();
            builder.Property(m => m.ImagePoster);
            builder.Property(m => m.CategoryId).IsRequired();

        }

       
    }
}
