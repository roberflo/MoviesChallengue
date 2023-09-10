using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Responses
{
    public class BaseResponse
    {
        public BaseResponse() => Success = true;
        public BaseResponse(string message)
        {
            Success = true;
            Message = message.Trim();
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public List<string>? ValidationErrors { get; set; }
    }
}
