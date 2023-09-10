using AutoMapper;
using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using Challenge.Movies.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CreateRatingCommandResponse>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        public CreateRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository, IHttpContextAccessor context)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _context = context;
        }

        public async Task<CreateRatingCommandResponse> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var createRatingCommandResponse = new CreateRatingCommandResponse();
            var user = new ApplicationUserInfo(_context);

            var validator = new CreateRatingCommandValidator(_ratingRepository, _context);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                createRatingCommandResponse.Success = false;
                createRatingCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createRatingCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
               
            }


            if (createRatingCommandResponse.Success)
            {
                var newRating = _mapper.Map<Rating>(request);
                
                var userEmail = user.GetEmail() ?? string.Empty;
                newRating.RateUser = userEmail;

                newRating = await _ratingRepository.AddAsync(newRating);
                var responseRating = await _ratingRepository.GetRatingById(newRating.RatingId);
                createRatingCommandResponse.Rating = _mapper.Map<CreateRatingDto>(newRating);
                
            }
            return createRatingCommandResponse;

        }
    }
}
