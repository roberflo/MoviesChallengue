using Challenge.Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Queries.DTO
{
    public class RatingViewModel
    {
        public Guid RatingId { get; set; }
        public string RateOption { get; set; } = string.Empty;
        public MovieDto Movie { get; set; } = new MovieDto();
        public string RateUser { get; set; } = string.Empty;
    }
}
