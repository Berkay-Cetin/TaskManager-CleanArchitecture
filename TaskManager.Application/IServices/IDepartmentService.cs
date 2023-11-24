using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Domain;

namespace TaskManager.Application.IServices
{
    public interface IDepartmentService
    {
        Task<List<GetAllDepartmentsResponse>> GetAllDepartments();
        //Task<Department> GetDepartmentById(int id);
    }
}
