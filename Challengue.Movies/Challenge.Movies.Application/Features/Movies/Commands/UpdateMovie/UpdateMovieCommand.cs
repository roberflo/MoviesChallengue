using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest<UpdateMovieCommandResponse>
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;      
        public Guid CategoryId { get; set; }
    }
}
