using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Requests
{
    public class UpdateTaskRequest
    {
        public User Assignee { get; set; }
        public int AssignmentId { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public AssignStatus NewStatus { get; set; }
    }
}
