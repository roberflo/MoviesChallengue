using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest<DeleteMovieCommandResponse>
    {
        public Guid MovieId { get; set; }
    }
}
