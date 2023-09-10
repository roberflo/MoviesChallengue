using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie
{
    
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieCommandValidator(ICategoryRepository categoryRepository, IMovieRepository movieRepository)
        {
            _categoryRepository = categoryRepository;
            _movieRepository = movieRepository;

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters. ");

            RuleFor(p => p.ReleaseDate).NotEmpty().WithMessage("{PropertyName} is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("No dates before today");


            RuleFor(p => p.CategoryId).MustAsync(ValidCategory)
                .WithMessage("There must be a valid category id");


            RuleFor(p => p.MovieId).NotEmpty().WithMessage("{PropertyName} is required.")
            .MustAsync(ValidMovie)
                .WithMessage("There must be a valid movie id");
        }
        private async Task<bool> ValidCategory(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return category != null;
        }
        private async Task<bool> ValidMovie(Guid id, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            return movie != null;
        }
    }
}
