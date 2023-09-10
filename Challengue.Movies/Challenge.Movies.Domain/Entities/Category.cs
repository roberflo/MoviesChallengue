using Challenge.Movies.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Domain.Entities
{
    public class Category:AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Movie>? Movies { get; set; }

    }
}
