using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IRepositories;
using TaskManager.Application.IServices;

namespace TaskManager.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<GetAllDepartmentsResponse>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            return departments.Select(department => new GetAllDepartmentsResponse
            {
                Id = department.Id,
                Name = department.Name
            }).ToList();
        }
    }
}
