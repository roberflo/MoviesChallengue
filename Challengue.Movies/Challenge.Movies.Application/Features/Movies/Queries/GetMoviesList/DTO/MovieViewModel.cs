using Challenge.Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO
{
    public class MovieViewModel
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public byte[]? ImagePoster { get; set; }
        public string Category { get; set; }
    }
}
