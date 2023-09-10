using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Queries.DTO
{
    public class MovieDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public byte[]? ImagePoster { get; set; }
    }
}
