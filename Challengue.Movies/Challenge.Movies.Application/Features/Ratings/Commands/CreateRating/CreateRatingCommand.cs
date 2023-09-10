using Challenge.Movies.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommand : IRequest<CreateRatingCommandResponse>
    {
        public RatingOptions RateOption { get; set; }
        public Guid MovieId { get; set; }
    }
}
