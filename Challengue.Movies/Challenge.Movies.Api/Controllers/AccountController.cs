using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application.Contracts.Identity;
using Challenge.Movies.Application.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Challenge.Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegistrationRequest request)
        {
            try
            {
                var user = await _authenticationService.RegisterAsync(request);
                return Ok(user);
            }
            catch (Exception e)
            {

               return StatusCode(406, e.Message);
            }
           
        }
        
    }
}
