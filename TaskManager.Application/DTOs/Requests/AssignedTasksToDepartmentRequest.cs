using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Requests
{
    public class AssignedTasksToDepartmentRequest
    {
        public User Assignee { get; set; }
    }
}
