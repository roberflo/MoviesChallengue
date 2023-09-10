using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList;
using Challenge.Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Contracts.Persistence
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IReadOnlyList<Movie>> GetMovies(GetMoviesListQuery request);
    }
}
