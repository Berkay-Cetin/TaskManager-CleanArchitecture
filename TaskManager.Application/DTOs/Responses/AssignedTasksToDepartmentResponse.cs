using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Responses
{
    public class AssignedTasksToDepartmentResponse
    {
        public List<Assignment> AssignedTasks { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
