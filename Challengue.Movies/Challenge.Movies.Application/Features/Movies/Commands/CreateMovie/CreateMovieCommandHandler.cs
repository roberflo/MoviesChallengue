using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMapper mapper, IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var createMovieCommandResponse = new CreateMovieCommandResponse();

            var validator = new CreateMovieCommandValidator(_categoryRepository);
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
                var newMovie = _mapper.Map<Movie>(request);
                newMovie = await _movieRepository.AddAsync(newMovie);
               
                createMovieCommandResponse.Movie = _mapper.Map<CreateMovieDto>(newMovie);
            }
            return createMovieCommandResponse;
        }
    }
}
