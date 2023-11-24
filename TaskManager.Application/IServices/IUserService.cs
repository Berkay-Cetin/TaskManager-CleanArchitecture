using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;

namespace TaskManager.Application.IServices
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
        Task<List<UserResponse>> GetAllUsers();
        Task<MyProfileResponse> GetMyProfile(MyProfileRequest request);
    }
}
