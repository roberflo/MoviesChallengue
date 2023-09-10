using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList;
using Challenge.Movies.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Queries.DownloadMovieImage
{
    
    public class DownloadMovieImageQueryHandler : IRequestHandler<DownloadMovieImageQuery, DownloadMovieImageResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public DownloadMovieImageQueryHandler(IMapper mapper, IMovieRepository movieRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;

        }

        public async Task<DownloadMovieImageResponse> Handle(DownloadMovieImageQuery request,
          CancellationToken cancellationToken)
        {
            var response = new DownloadMovieImageResponse();
            var movie = (await _movieRepository.GetByIdAsync(request.MovieId));
            response.File = movie.ImagePoster;

            return response;
        }
    }
}
