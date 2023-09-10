using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.AddMovieImage
{
    
    public class UpdateMovieImageCommandValidator : AbstractValidator<UpdateMovieImageCommand>
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieImageCommandValidator(IMovieRepository movieRepository)
        {
           _movieRepository = movieRepository;

            RuleFor(p => p.MovieId).NotEmpty().WithMessage("{PropertyName} is required.")
            .MustAsync(ValidMovie)
                .WithMessage("There must be a valid movie id");

            RuleFor(p => p.File).NotEmpty().WithMessage("{PropertyName} is required.");
        }
        private async Task<bool> ValidMovie(Guid id, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            return movie != null;
        }

    }
}
