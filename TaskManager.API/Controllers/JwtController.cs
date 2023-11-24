using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IServices;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private IConfiguration _config;
        public JwtController(IUserService userService, ICurrentUserService currentUserService, IConfiguration config)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _config = config;
        }

        [HttpGet,Authorize]
        public IActionResult GetMe()
        {
            var currUser = _currentUserService.GetCurrentUser();
            return Ok(currUser);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            var response = await _userService.Login(loginRequest);

            if (response.UserId == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                var response = await _userService.Register(registerRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
