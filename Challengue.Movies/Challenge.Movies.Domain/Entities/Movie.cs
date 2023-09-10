using Challenge.Movies.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Domain.Entities
{
    public class Movie:AuditableEntity
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public byte[]? ImagePoster { get; set; } 
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } 

        public ICollection<Rating> Ratings { get; } 


    }
}
