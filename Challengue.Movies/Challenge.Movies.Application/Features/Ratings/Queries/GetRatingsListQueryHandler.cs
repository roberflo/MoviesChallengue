using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Movies.Application.Features.Ratings.Queries.DTO;
using AutoMapper;
using Challenge.Movies.Domain.Entities;
using Challenge.Movies.Application.Contracts.Persistence;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Challenge.Movies.Api.Utility;

namespace Challenge.Movies.Application.Features.Ratings.Queries
{
    public class GetRatingsListQueryHandler : IRequestHandler<GetRatingsListQuery, List<RatingViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly IHttpContextAccessor _context;
        public GetRatingsListQueryHandler(IMapper mapper, IRatingRepository ratingRepository, IHttpContextAccessor context)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _context = context;
        }
        public async Task<List<RatingViewModel>> Handle(GetRatingsListQuery request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUserInfo(_context);
            var userEmail = user.GetEmail() ?? string.Empty;
            var ratings = await _ratingRepository.GetRatingsFromUser(userEmail);
            return _mapper.Map<List<RatingViewModel>>(ratings);
        }
    }
}
