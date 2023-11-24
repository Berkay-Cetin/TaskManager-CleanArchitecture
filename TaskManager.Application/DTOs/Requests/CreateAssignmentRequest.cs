using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Requests
{
    public class CreateAssignmentRequest
    {
        public string Description { get; set; }
        public string Detail { get; set; }
        public int CreatorId { get; set; }
        public int AssigneeId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
