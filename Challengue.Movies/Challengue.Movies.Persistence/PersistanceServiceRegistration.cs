using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Persistence.Repositories;
using Challengue.Movies.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChallengeDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ChallengeMovieConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
