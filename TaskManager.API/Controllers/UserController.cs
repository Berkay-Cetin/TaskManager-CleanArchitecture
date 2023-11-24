using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IServices;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();
            return Ok(response);
        }

        [HttpGet("GetMyProfile")]
        public async Task<ActionResult<MyProfileResponse>> GetMyProfile([FromQuery] MyProfileRequest request)
        {
            var response = await _userService.GetMyProfile(request);

            if (!response.IsSuccess)
            {
                return NotFound(response.ErrorMessage);
            }

            return Ok(response);
        }
    }
}
