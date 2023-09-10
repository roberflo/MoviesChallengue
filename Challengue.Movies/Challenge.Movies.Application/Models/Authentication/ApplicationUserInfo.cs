using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace Challenge.Movies.Api.Utility
{
    public class ApplicationUserInfo
    {
        private readonly IHttpContextAccessor _context;

        public ApplicationUserInfo(IHttpContextAccessor context)
        {
            _context = context;
        }
        public string? GetEmail()
        {
            var userClaims = _context.HttpContext?.User.Claims;
            return (userClaims != null) ? userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value :string.Empty;
        }

        public string? GetUserName()
        {

            return _context.HttpContext?.User?.Identity?.Name;
        }

        public string? GetRole()
        {
            var userClaims = _context.HttpContext?.User.Claims;

            return (userClaims != null) ? userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value : string.Empty;
        }
    }
}
