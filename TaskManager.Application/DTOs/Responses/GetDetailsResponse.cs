using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs.Responses
{
    public class GetDetailsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public UserResponse Assignee { get; set; }
        public UserResponse Creator { get; set; }
        public AssignStatusResponse Status { get; set; }
    }
}
