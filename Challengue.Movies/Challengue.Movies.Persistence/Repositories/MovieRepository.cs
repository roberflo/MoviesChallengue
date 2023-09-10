using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList;
using Challenge.Movies.Application.Features.Responses;
using Challenge.Movies.Domain.Entities;
using Challengue.Movies.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ChallengeDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<Movie>> GetMovies(GetMoviesListQuery request)
        {
            var movies =  _dbContext.Movies
                .Include(c=>c.Category)
                 .Include(c => c.Ratings)
                .AsQueryable();


            if (!String.IsNullOrEmpty(request.SearchString))
            {
                movies = movies.Where(s => s.Name.Contains(request.SearchString)
                                       || s.Synopsis.Contains(request.SearchString));
            }

            if(!String.IsNullOrEmpty(request.FilterString)&& !String.IsNullOrEmpty(request.Filter))
            switch (request.Filter)
            {
                    case "release_year":
                        movies = movies.Where(s => s.ReleaseDate.Year == Int64.Parse(request.FilterString));
                        break;
                    case "category":
                    movies = movies.Where(s => s.Category.Name == request.FilterString);
                    break;
                default:
                    movies = movies.OrderBy(s => s.CreatedDate);
                    break;
            }

            switch (request.Order)
            {
                case "release_date":
                    switch (request.Sort)
                    {
                        case "desc":
                            movies = movies.OrderByDescending(s => s.ReleaseDate);
                            break;
                        case "asc":
                            movies = movies.OrderBy(s => s.ReleaseDate);
                            break;

                        default:
                            movies = movies.OrderBy(s => s.ReleaseDate);
                            break;
                    }                  
                    break;
                case "name":
                    switch (request.Sort)
                    {
                        case "desc":
                            movies = movies.OrderByDescending(s => s.Name);
                            break;
                        case "asc":
                            movies = movies.OrderBy(s => s.Name);
                            break;

                        default:
                            movies = movies.OrderBy(s => s.Name);
                            break;
                    }
                    break;
                 
                case "created_date":
                    switch (request.Sort)
                    {
                        case "desc":
                            movies = movies.OrderByDescending(s => s.CreatedDate);
                            break;
                        case "asc":
                            movies = movies.OrderBy(s => s.CreatedDate);
                            break;

                        default:
                            movies = movies.OrderBy(s => s.CreatedDate);
                            break;
                    }
                    break;
                   
                case "rating":
                    switch (request.Sort)
                    {
                        case "desc":
                            movies = movies.OrderByDescending(s => s.Ratings.Average(a=>((int)a.RateOption)));
                            break;
                        case "asc":
                            movies = movies.OrderBy(s => s.Ratings.Average(a => ((int)a.RateOption)));
                            break;

                        default:
                            movies = movies.OrderBy(s => s.Ratings.Average(a => ((int)a.RateOption)));
                            break;
                    }
                    break;
                   
                default:
                    movies = movies.OrderBy(s => s.CreatedDate);
                    break;
            }

            //pagination
            return await PaginatedList<Movie>.PaginateAsync(movies, request.Number, request.PageSize);
        }
    }
}
