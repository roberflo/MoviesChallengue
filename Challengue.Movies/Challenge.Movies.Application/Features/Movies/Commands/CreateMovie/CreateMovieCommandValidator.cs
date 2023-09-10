using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Ratings.Commands.CreateRating;
using Challenge.Movies.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateMovieCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters. ");

            RuleFor(p => p.ReleaseDate).NotEmpty().WithMessage("{PropertyName} is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("No dates before today");


            RuleFor(p=> p.CategoryId).MustAsync(ValidCategory)
                .WithMessage("There must be a valid category id");
        }
        private async Task<bool> ValidCategory(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return category != null;
        }

    }
}
