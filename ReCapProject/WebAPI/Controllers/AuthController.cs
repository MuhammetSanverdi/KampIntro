using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            var accessToken = _authService.CreateAccessToken(userToLogin.Data);
            if (accessToken.Success)
            {
                return Ok(accessToken.Data);                 
            }
            return BadRequest(accessToken.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = _authService.Register(userForRegisterDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            var accessToken = _authService.CreateAccessToken(result.Data);
            if (!accessToken.Success)
            {
                return BadRequest(accessToken.Message);
            }
            return Ok(accessToken.Data);

        }
    }
}
