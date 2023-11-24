using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.IServices
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
