using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie;
using Challenge.Movies.Application.Features.Ratings.Commands.CreateRating;
using Challenge.Movies.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, DeleteRatingCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly IHttpContextAccessor _context;
        public DeleteRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository, IHttpContextAccessor context)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _context = context;
        }

        public async Task<DeleteRatingCommandResponse> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteRatingCommandValidator(_ratingRepository, _context);
            var validationResult = await validator.ValidateAsync(request);
            var deleteRatingCommandResponse = new DeleteRatingCommandResponse();

            if (validationResult.Errors.Any())
            {
                deleteRatingCommandResponse.Success = false;
                deleteRatingCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    deleteRatingCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (deleteRatingCommandResponse.Success)
            {
                var movieToDelete = await _ratingRepository.GetByIdAsync(request.RatingId);
                await _ratingRepository.DeleteAsync(movieToDelete);
            }
               
            return deleteRatingCommandResponse;

        }

        
    }
}
