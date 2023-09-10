using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMoviesListQuery, List<MovieViewModel>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieListQueryHandler(IMapper mapper, IMovieRepository movieRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
           
        }

        public async Task<List<MovieViewModel>> Handle(GetMoviesListQuery request,
          CancellationToken cancellationToken)
        {
            var movies = (await _movieRepository.GetMovies(request)).ToList();
            var moviesViewModel = _mapper.Map<List<MovieViewModel>>(movies);

            return moviesViewModel;
        }
    }
}
