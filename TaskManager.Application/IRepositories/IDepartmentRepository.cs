using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
    }
}
