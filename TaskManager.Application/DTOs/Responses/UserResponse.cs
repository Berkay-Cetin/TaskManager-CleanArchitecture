using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Responses
{
    public class UserResponse
    {
        public int UserId {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Department Department { get; set; }
        public string Title {  get; set; }
        public bool IsActive { get; set; }
    }
}
