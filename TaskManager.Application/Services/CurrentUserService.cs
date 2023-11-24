using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IServices;

namespace TaskManager.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUserResponse GetCurrentUser()
        {
            var user = new CurrentUserResponse();
            if (_httpContextAccessor.HttpContext != null)
            {
                user = new CurrentUserResponse
                {
                    Id = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    Name = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name),
                    Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                    Title = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role)
                };
            }
            return user;
        }
    }
}
