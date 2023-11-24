using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Responses;

namespace TaskManager.Application.IServices
{
    public interface ICurrentUserService
    {
        CurrentUserResponse GetCurrentUser();
    }
}
