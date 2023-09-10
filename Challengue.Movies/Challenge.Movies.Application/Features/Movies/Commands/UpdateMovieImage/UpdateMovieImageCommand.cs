using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.AddMovieImage
{
    public class UpdateMovieImageCommand : IRequest<UpdateMovieImageCommandResponse>
    {
        public byte[] File { get; set; }
        public Guid MovieId { get; set; }
    }
}
