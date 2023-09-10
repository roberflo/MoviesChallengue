using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie;
using Challenge.Movies.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.AddMovieImage
{


    public class UpdateMovieImageCommandHandler : IRequestHandler<UpdateMovieImageCommand, UpdateMovieImageCommandResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateMovieImageCommandHandler(ICategoryRepository categoryRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateMovieImageCommandResponse> Handle(UpdateMovieImageCommand request, CancellationToken cancellationToken)
        {
            var addMovieImageCommandResponse = new UpdateMovieImageCommandResponse();

            var validator = new UpdateMovieImageCommandValidator(_movieRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                addMovieImageCommandResponse.Success = false;
                addMovieImageCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    addMovieImageCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (addMovieImageCommandResponse.Success)
            {
                var movieUpdate = await _movieRepository.GetByIdAsync(request.MovieId);
                movieUpdate.ImagePoster = request.File;
                await _movieRepository.UpdateAsync(movieUpdate);
            }

            return addMovieImageCommandResponse;

        }

    }
}

