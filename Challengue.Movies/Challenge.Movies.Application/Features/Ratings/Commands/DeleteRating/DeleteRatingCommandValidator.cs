using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Ratings.Commands.CreateRating;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.DeleteRating
{
    
    public class DeleteRatingCommandValidator : AbstractValidator<DeleteRatingCommand>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IHttpContextAccessor _context;
        public DeleteRatingCommandValidator(IRatingRepository ratingRepository, IHttpContextAccessor context)
        {
            _ratingRepository = ratingRepository;
            _context = context;

            RuleFor(p => p.RatingId).NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(r => r).MustAsync(ApprovedToDeleteBySameUserThatCreatesTheRating)
                .WithMessage("a rating must be deleted just by the user that creates the rating");


        }

        

        private async Task<bool> ApprovedToDeleteBySameUserThatCreatesTheRating(DeleteRatingCommand e, CancellationToken cancellationToken)
        {
            var user = new ApplicationUserInfo(_context);         
            return (await _ratingRepository.IsCreatedByUser(e.RatingId, user.GetEmail()));
        }
    }
}
