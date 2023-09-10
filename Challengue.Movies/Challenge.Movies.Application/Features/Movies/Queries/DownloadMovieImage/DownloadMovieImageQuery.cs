using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Queries.DownloadMovieImage
{
    public class DownloadMovieImageQuery: IRequest<DownloadMovieImageResponse>
    {
        public Guid MovieId { get; set; }
    }
}
