using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Responses
{
    public class CurrentUserResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title {  get; set; }
    }
}
