using Challenge.Movies.Application.Features.Ratings.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Queries
{
    public class GetRatingsListQuery : IRequest<List<RatingViewModel>>
    {
    }
}
