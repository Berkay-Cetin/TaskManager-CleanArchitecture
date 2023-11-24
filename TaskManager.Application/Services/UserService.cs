using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IRepositories;
using TaskManager.Application.IServices;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _deptRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService, IDepartmentRepository deptRepository)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _deptRepository = deptRepository;
        }

        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            var dept = await _deptRepository.GetDepartmentById(registerRequest.DepartmentId);
            var newUser = new User
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                Contact = registerRequest.Contact,
                DepartmentId = registerRequest.DepartmentId,
                Department = dept,
                Title = registerRequest.Title,
                Password = PassHasher.HashPassword(registerRequest.Password),
                IsActive = true
            };

            await _userRepository.Register(newUser);
            var userTemp = await _userRepository.GetUserByEmail(newUser.Email);
            return new RegisterResponse
            {
                Id = userTemp.UserId
            };
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            string username = loginRequest.Username;
            string password = loginRequest.Password;

            var user = await _userRepository.GetUserByEmail(username);

            if (user != null && user.IsActive)
            {
                var token = _jwtService.GenerateToken(user);
                if (PassHasher.VerifyPassword(password, user.Password))
                {
                    return new LoginResponse { UserId = user.UserId, JwtToken = token };
                }
            }

            return new LoginResponse { UserId = null };
        }
        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Where(a=>a.IsActive).Select(user => new UserResponse
            {
                Name = user.UserName,
                Email = user.Email,
                Contact = user.Contact,
                Title = user.Title,
                Department = user.Department,
                IsActive = user.IsActive
            }).ToList();
        }

        public async Task<MyProfileResponse> GetMyProfile(MyProfileRequest request)
        {
            try
            {
                var user = await _userRepository.GetUserById(request.UserId);

                if (user != null)
                {
                    var userProfile = new User
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Department = user.Department,
                        Title = user.Title,
                        Contact = user.Contact
                    };

                    return new MyProfileResponse
                    {
                        UserProfile = userProfile,
                        IsSuccess = true
                    };
                }

                return new MyProfileResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Couldn't find user."
                };
            }
            catch (Exception ex)
            {
                return new MyProfileResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Couldn't get profile informations: {ex.Message}"
                };
            }
        }

    }
}
