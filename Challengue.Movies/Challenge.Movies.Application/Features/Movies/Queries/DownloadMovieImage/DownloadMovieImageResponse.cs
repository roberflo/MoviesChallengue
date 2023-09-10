using Challenge.Movies.Application.Features.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Challenge.Movies.Application.Features.Movies.Queries.DownloadMovieImage
{
    public class DownloadMovieImageResponse : BaseResponse
    {
        public DownloadMovieImageResponse() : base() { }

        public byte[]? File { get; set; }  
    }
   

}
