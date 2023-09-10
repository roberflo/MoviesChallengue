using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<CreateMovieCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
