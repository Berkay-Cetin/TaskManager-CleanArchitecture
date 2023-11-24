using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Responses
{
    public class GetAllAssignmentsResponse
    {
        public UserResponse Creator { get; set; }
        public UserResponse Assignee { get; set; }
        public string Description { get; set; }
        public AssignStatusResponse Status { get; set; }
    }

    public enum AssignStatusResponse
    {
        Created = 1,
        InProgress = 2,
        Done = 3,
        Cancelled = 4
    }
}
