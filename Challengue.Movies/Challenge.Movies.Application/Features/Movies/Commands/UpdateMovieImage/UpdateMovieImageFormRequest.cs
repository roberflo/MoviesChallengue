using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.AddMovieImage
{
    public class UpdateMovieImageFormRequest
    {
        public IFormFile File { get; set; }
    }
}
