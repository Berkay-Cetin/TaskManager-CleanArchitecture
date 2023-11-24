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
    public interface IAssignmentRepository
    {

        Task<List<Assignment>> GetAllAssignments();
        Task<Assignment> GetAssignmentById(int id);
        Task CreateAssignment(Assignment assignment);
        Task Update(Assignment assignment);
        Task Delete(Assignment assignment);
        Task<List<Assignment>> GetAssignmentsByDepartment(Department department);
    }
}
