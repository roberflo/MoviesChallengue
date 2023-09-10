using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Challenge.Movies.Application.Features.Ratings.Queries.DTO;
using Challenge.Movies.Application.Features.Ratings.Queries;
using Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using Challenge.Movies.Application.Features.Ratings.Commands.CreateRating;
using Challenge.Movies.Application.Features.Ratings.Commands.DeleteRating;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Challenge.Movies.Api.Controllers
{
   
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("api/Rating", Name = "GetAllRatings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RatingViewModel>>> GetAllRatings()
        {
            //get all for authenticated user
            var dtos = await _mediator.Send(new GetRatingsListQuery());
            return Ok(dtos);
        }

        [Authorize]
        [HttpPost("api/Rating", Name = "AddRating")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateRatingCommandResponse>> Create([FromBody] CreateRatingCommand createRatingCommand)
        {
            var response = await _mediator.Send(createRatingCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("api/Rating/{id}", Name = "DeleteRating")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
          
            var deleteRatingCommand = new DeleteRatingCommand() { RatingId = id };
            var validation =  await _mediator.Send(deleteRatingCommand);
            if (validation.ValidationErrors != null && validation.ValidationErrors.Any())
            {
                return StatusCode(406, validation);
            }
            return NoContent();
            
        }

    }
}
