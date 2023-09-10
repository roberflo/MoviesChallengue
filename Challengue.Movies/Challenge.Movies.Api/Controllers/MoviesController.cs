using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application.Features.Movies.Commands.AddMovieImage;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie;
using Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie;
using Challenge.Movies.Application.Features.Movies.Queries.DownloadMovieImage;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Application.Features.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Challenge.Movies.Api.Controllers
{

    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Movie/{id}/image", Name = "DownloadMovieImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<FileResult> DownloadMovieImage(Guid id)
        {
            var request = new DownloadMovieImageQuery() { MovieId = id };
            var response = await _mediator.Send(request);

            return File(response.File, "image/jpeg");
        }

        [HttpGet("api/Movie", Name = "GetAllMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieViewModel>>> GetAllMovies([FromQuery] GetMoviesListQuery request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("api/Movie", Name = "AddMovie")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateMovieCommandResponse>> Create([FromBody] CreateMovieCommand createMovieCommand)
        {
            var response = await _mediator.Send(createMovieCommand);
            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("api/Movie/{id}/image", Name = "Update Movie Image")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> UpdateImage(Guid id, [FromForm] UpdateMovieImageFormRequest addMovieImageRequest)
        {


            var addMovieImageCommand = new UpdateMovieImageCommand()
            {
                MovieId = id,
                File = ImageConverter.FileImageToByteArray(addMovieImageRequest.File),
            };
            var update = await _mediator.Send(addMovieImageCommand);
            if (update.ValidationErrors != null && update.ValidationErrors.Any())
            {
                return StatusCode(406, update);
            }
            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("api/Movie/{id}", Name = "UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateMovieCommand updateMovieCommand)
        {
            updateMovieCommand.MovieId = id;
            var update = await _mediator.Send(updateMovieCommand);
            if (update.ValidationErrors != null && update.ValidationErrors.Any())
            {
                return StatusCode(406, update);
            }
            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("api/Movie/{id}", Name = "DeleteMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {

            var deleteMovieCommand = new DeleteMovieCommand { MovieId = id };
            var delete = await _mediator.Send(deleteMovieCommand);
            if (delete.ValidationErrors != null && delete.ValidationErrors.Any())
            {
                return StatusCode(406, delete);
            }
            return NoContent();
        }
    }
}
