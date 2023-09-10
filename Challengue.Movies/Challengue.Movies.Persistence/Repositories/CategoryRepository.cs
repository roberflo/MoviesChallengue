using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Domain.Entities;
using Challengue.Movies.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence.Repositories
{
    
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ChallengeDbContext dbContext) : base(dbContext) { }
    }
}
