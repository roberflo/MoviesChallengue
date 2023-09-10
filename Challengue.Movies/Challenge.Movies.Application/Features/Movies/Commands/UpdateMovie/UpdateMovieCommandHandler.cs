using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using Challenge.Movies.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, UpdateMovieCommandResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(ICategoryRepository categoryRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var createMovieCommandResponse = new UpdateMovieCommandResponse();

            var validator = new UpdateMovieCommandValidator(_categoryRepository, _movieRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                createMovieCommandResponse.Success = false;
                createMovieCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createMovieCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                
            }
            if (createMovieCommandResponse.Success)
            {
                var movieUpdate = await _movieRepository.GetByIdAsync(request.MovieId);
                _mapper.Map(request, movieUpdate);
                await _movieRepository.UpdateAsync(movieUpdate);
            }

            return createMovieCommandResponse;

        }
    }
}
