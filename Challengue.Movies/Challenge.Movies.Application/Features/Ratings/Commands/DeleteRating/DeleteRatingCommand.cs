using Challenge.Movies.Application.Features.Ratings.Commands.CreateRating;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest<DeleteRatingCommandResponse>
    {
        public Guid RatingId { get; set; }
    }
}
