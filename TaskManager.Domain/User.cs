using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contact {  get; set; }
        public int DepartmentId {  get; set; }
        public Department Department {  get; set; }
        public string Title {  get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public ICollection<Assignment> CreatedAssignments { get; set; } = new List<Assignment>();
        [JsonIgnore]
        public ICollection<Assignment> AssignedAssignments { get; set; } = new List<Assignment>();
    }
}
