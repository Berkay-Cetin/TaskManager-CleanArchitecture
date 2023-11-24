using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IServices;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult<List<GetAllDepartmentsResponse>>> GetAllDepartments()
        {
            var response = await _departmentService.GetAllDepartments();
            return Ok(response);
        }
    }
}
