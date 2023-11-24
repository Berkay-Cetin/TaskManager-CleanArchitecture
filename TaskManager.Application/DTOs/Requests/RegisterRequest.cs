﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Requests
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }
    }
}
