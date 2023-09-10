using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Requests
{
    public class BaseRequest
    {
        public string SearchString { get; set; } = string.Empty;
        public string Filter { get; set; } = string.Empty;
        public string FilterString { get; set; } = string.Empty;
        //Pagination
        public int Number { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Sort { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
    }
}
