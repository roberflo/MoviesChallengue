using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Ratings.Commands.DeleteRating;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie
{
    

    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
       
        private readonly IMovieRepository _movieRepository;
        public DeleteMovieCommandValidator( IMovieRepository movieRepository)
        {
           
            _movieRepository = movieRepository;

            RuleFor(p => p.MovieId).NotEmpty().WithMessage("{PropertyName} is required.")
            .MustAsync(ValidMovie)
                .WithMessage("There must be a valid movie id");
        }
       
        private async Task<bool> ValidMovie(Guid id, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            return movie != null;
        }
    }
}
