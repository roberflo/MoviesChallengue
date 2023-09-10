using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.CreateRating
{
    public  class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IHttpContextAccessor _context;
        public CreateRatingCommandValidator(IRatingRepository  ratingRepository, IHttpContextAccessor context)
        {
            _ratingRepository = ratingRepository;
            _context = context;

            RuleFor(p => p.MovieId).NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(r => r).MustAsync(MovieAndRateUserUnique)
                .WithMessage("a rating with the same user and movie already exist");

            
        }

        private async Task<bool> MovieAndRateUserUnique(CreateRatingCommand e, CancellationToken cancellationToken)
        {
            var user = new ApplicationUserInfo(_context);
            var userEmail = user.GetEmail() ?? string.Empty;
            return !(await _ratingRepository.IsMovieAndRateUserUnique(e.MovieId, userEmail));
        }
    }
}
