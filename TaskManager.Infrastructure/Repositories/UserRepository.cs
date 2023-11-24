using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IRepositories;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AssignmentDbContext _assignmentDbContext;

        public UserRepository(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _assignmentDbContext.Users
            .SingleOrDefaultAsync(u => u.Email == email);
        }
        public async Task<int> Register(User user)
        {
            _assignmentDbContext.Users.Add(user);
            await _assignmentDbContext.SaveChangesAsync();
            return user.UserId;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _assignmentDbContext.Users
                .Where(user => user.IsActive)
                .Select(user => new User
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    DepartmentId = user.DepartmentId,
                    IsActive = user.IsActive
                })
                .ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _assignmentDbContext.Users.FindAsync(id);
        }
    }
}
