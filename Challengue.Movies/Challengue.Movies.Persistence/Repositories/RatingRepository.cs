using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Domain.Entities;
using Challengue.Movies.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ChallengeDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<Rating>> GetRatingsFromUser(string userEmail)
        {
            return await _dbContext.Ratings.Include(r=>r.Movie).Where(r=>r.RateUser == userEmail).ToListAsync();      
        }

        public async Task<Rating> GetRatingById(Guid ratingId)
        {
            return await _dbContext.Ratings.Include(r => r.Movie).Where(r=>r.RatingId == ratingId).SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Rating>> GetRatings()
        {
            return await _dbContext.Ratings.Include(r => r.Movie).ToListAsync();
        }

        public Task<bool> IsMovieAndRateUserUnique(Guid movieId, string rateUser)
        {
           var matches = _dbContext.Ratings.Any(r=>r.RateUser.Equals(rateUser) && r.Movie.MovieId.Equals(movieId));
            return Task.FromResult(matches);
        }

      
        public Task<bool> IsCreatedByUser(Guid ratingId, string? User)
        {
            var matches = _dbContext.Ratings.Any(r => r.RateUser.Equals(User) && r.RatingId.Equals(ratingId));
            return Task.FromResult(matches);
        }
    }
}
