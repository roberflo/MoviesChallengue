using Challenge.Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Contracts.Persistence
{
    public  interface IRatingRepository: IAsyncRepository<Rating>
    {
        Task<IReadOnlyList<Rating>> GetRatingsFromUser(string userEmail);
        Task<IReadOnlyList<Rating>> GetRatings();
        Task<Rating> GetRatingById(Guid ratingId);
        Task<bool> IsMovieAndRateUserUnique(Guid movieId, string rateUser);
        Task<bool> IsCreatedByUser(Guid ratingId, string? User);
    }
}
