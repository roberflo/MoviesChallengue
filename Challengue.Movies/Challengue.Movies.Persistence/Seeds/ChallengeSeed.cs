using Challenge.Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence.Seeds
{
    public class ChallengeSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var categoryIdGuid = Guid.Parse("35222c2f-f7d3-42e6-9db6-f9aa199bb514");
            var movieIdGuid = Guid.Parse("70add475-5bfc-499d-817e-90a301378f22");
            var ratingIdGuid = Guid.Parse("b66bdfdb-f178-434e-bbc5-2d1b06d75b5c");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = categoryIdGuid,
                    Name = "Terror",
                    CreatedBy = "roberto@hireme.com",
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = movieIdGuid,
                    Name = "The Basement",
                    CategoryId = categoryIdGuid,
                    ReleaseDate = DateTime.Now,
                    Synopsis = "College students trapped in a haunted house with a living serial killer.",
                    CreatedBy = "roberto@hireme.com",
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                RatingId = ratingIdGuid,
                MovieId = movieIdGuid,
                RateOption = RatingOptions.Five,
                RateUser = "roberto@hireme.com",
                CreatedBy = "roberto@hireme.com",
                CreatedDate = DateTime.Now
            });

            var categoryIdGuid2 = Guid.Parse("99b413d5-626c-46c0-a687-6b1cf12dbcad");
            var movieIdGuid2 = Guid.Parse("2c3220c4-c111-4701-9d04-394bc4e9a2e8");
            var ratingIdGuid2 = Guid.Parse("6566622d-a07c-4307-9d57-7fe4eb1d266f");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = categoryIdGuid2,
                    Name = "Comedy",
                    CreatedBy = "roberto@hireme.com",
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = movieIdGuid2,
                    Name = "The Wedding Crasher",
                    CategoryId = categoryIdGuid2,
                    ReleaseDate = DateTime.Now,
                    Synopsis = "A wedding crasher falls for a crime boss’s daughter and faces hilarious challenges",
                    CreatedBy = "roberto@hireme.com",
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                RatingId = ratingIdGuid2,
                MovieId = movieIdGuid2,
                RateOption = RatingOptions.Five,
                RateUser = "roberto@hireme.com",
                CreatedBy = "roberto@hireme.com",
                CreatedDate = DateTime.Now
            });

        }
    }
}
