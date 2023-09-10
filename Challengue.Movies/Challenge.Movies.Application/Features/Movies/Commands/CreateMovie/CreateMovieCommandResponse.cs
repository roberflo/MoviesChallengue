using Challenge.Movies.Application.Features.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandResponse : BaseResponse
    {
        public CreateMovieCommandResponse():base() { }
        public CreateMovieDto? Movie { get; set; } = default;
    }
}
