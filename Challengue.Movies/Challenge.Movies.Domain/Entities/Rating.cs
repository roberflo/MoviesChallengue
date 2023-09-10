using Challenge.Movies.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Domain.Entities
{
    public class Rating : AuditableEntity
    {
        public Guid RatingId { get; set; }
        public RatingOptions RateOption { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } 
        public string RateUser { get; set; } = string.Empty;

    }
    public enum RatingOptions
    {
        One = 1, Two = 2, Three = 3, Four = 4, Five = 5
    }

}

