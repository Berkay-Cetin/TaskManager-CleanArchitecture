using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.IRepositories;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AssignmentDbContext _assignmentDbContext;

        public DepartmentRepository(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _assignmentDbContext.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _assignmentDbContext.Departments.FindAsync(id);
        }
    }
}
