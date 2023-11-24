using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Domain;

namespace TaskManager.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<int> Register(User user);
    }
}
