using Challenge.Movies.Domain.Entities;
using Challenge.Movies.Domain.Entities.Common;
using Challenge.Movies.Persistence.Configurations;
using Challenge.Movies.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challengue.Movies.Persistence
{
    public class ChallengeDbContext: DbContext
    {
        public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeDbContext).Assembly);
            //Configurations
            MovieConfiguration.MovieModelCreating(modelBuilder);
            RatingConfiguration.RatingModelCreating(modelBuilder);
            CategoryConfiguration.CategoryModelCreating(modelBuilder);
            //seed data
            ChallengeSeed.SeedData(modelBuilder);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now; break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now; break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
