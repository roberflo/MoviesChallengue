using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Application.Features.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQuery : BaseRequest, IRequest<List<MovieViewModel>>
    {
        
    }
}
