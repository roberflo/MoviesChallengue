using Challenge.Movies.Application.Features.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandResponse : BaseResponse
    {
        public CreateRatingCommandResponse():base() { }
        public CreateRatingDto? Rating { get; set; } = default;
    }
}
