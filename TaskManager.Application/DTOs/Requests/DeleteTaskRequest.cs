using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs.Requests
{
    public class DeleteTaskRequest
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
