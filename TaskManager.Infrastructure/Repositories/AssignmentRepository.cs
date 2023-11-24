using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IRepositories;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AssignmentDbContext _assignmentDbContext;

        public AssignmentRepository(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
        }

        public async Task<List<Assignment>> GetAllAssignments()
        {
            return await _assignmentDbContext.Assignments
                .Include(a => a.Creator)
                .Include(a => a.Assignee)
                .ToListAsync();
        }
        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await _assignmentDbContext.Assignments.FindAsync(id);
        }

        public async Task CreateAssignment(Assignment assignment)
        {
            _assignmentDbContext.Assignments.Add(assignment);
            await _assignmentDbContext.SaveChangesAsync();
        }

        public async Task Update(Assignment assignment)
        {
            _assignmentDbContext.Entry(assignment).State = EntityState.Modified;
            await _assignmentDbContext.SaveChangesAsync();
        }

        public async Task Delete(Assignment assignment)
        {
            _assignmentDbContext.Assignments.Remove(assignment);
            await _assignmentDbContext.SaveChangesAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsByDepartment(Department department)
        {
            return await _assignmentDbContext.Assignments
                .Where(a => a.Assignee.Department == department)
                .ToListAsync();
        }
    }
}
