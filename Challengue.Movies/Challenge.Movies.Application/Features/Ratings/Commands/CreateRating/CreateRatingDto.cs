using Challenge.Movies.Application.Features.Ratings.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingDto
    {
        public Guid RatingId { get; set; }
        public string RateOption { get; set; } = string.Empty;
        public string Movie { get; set; } = string.Empty;
        public string RateUser { get; set; } = string.Empty;
    }
}
