using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IServices;
using TaskManager.Application.Services;
using TaskManager.Domain;
using TaskManager.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        //private readonly IMediator _mediator;

        public TaskController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }


        [HttpPost("CreateAssignment")]
        public async Task<ActionResult<CreateAssignmentResponse>> CreateAssignment([FromBody] CreateAssignmentRequest request)
        {
            var response = await _assignmentService.CreateAssignment(request);
            return Ok(response);
        }

        [HttpGet("GetAllAssignments")]
        public async Task<ActionResult<List<GetAllAssignmentsResponse>>> GetAllAssignments()
        {
            var response = await _assignmentService.GetAllAssignments();
            return Ok(response);
        }

        [HttpGet("GetAssignmentDetails")]
        public async Task<ActionResult<GetDetailsResponse>> GetAssignmentDetails([FromQuery] GetDetailsRequest request)
        {
            var response = await _assignmentService.GetAssignmentDetails(request);
            if (response == null)
            {
                return NotFound("Belirtilen görev bulunamadı.");
            }
            return Ok(response);
        }

        [HttpPost("UpdateAssignmentStatus")]
        public async Task<ActionResult<UpdateAssignmentStatusResponse>> UpdateAssignmentStatus([FromBody] UpdateAssignmentStatusRequest request)
        {
            var response = await _assignmentService.UpdateAssignmentStatus(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult<UpdateTaskResponse>> UpdateTask([FromBody] UpdateTaskRequest request)
        {
            var response = await _assignmentService.UpdateTask(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<DeleteTaskResponse>> DeleteTask([FromBody] DeleteTaskRequest request)
        {
            var response = await _assignmentService.DeleteTask(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }

        [HttpGet("GetAssignedTasksToDepartment")]
        public async Task<ActionResult<AssignedTasksToDepartmentResponse>> GetAssignedTasksToDepartment([FromQuery] AssignedTasksToDepartmentRequest request)
        {
            var response = await _assignmentService.GetAssignedTasksToDepartment(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }


        /*
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
                
        [HttpGet("all-users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _assignmentService.GetAllUsers();
            return Ok(users);
            /*var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
        [HttpGet("all-assignments")]
        public async Task<ActionResult<List<Assignment>>> GetAllAssignments()
        {
            var assignments = await _assignmentService.GetAllAssignments();
            return Ok(assignments);
        }

        [HttpGet("all-departments")]
        public async Task<ActionResult<List<Assignment>>> GetAllDepartments()
        {
            var departments = await _assignmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("assignment-details")]
        public async Task<ActionResult<List<Assignment>>> GetAssignmentDetails(int assignmentId)
        {
            var assignment = await _assignmentService.GetDetails(assignmentId);
            if (assignment == null || assignment.Count == 0)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost("create-assignment")]
        public async Task<ActionResult<Assignment>> CreateAssignment(string description, string detail, int creatorId, int assigneeId)
        {
            var newAssignment = await _assignmentService.CreateAssignment(description, detail, creatorId, assigneeId);

            if (newAssignment == null)
            {
                return BadRequest("Invalid creator or assignee.");
            }

            return Ok(newAssignment);
        }

        [HttpPut("update-assignment-status")]
        public async Task<ActionResult> UpdateAssignmentStatus(int assignmentId, AssignStatus newStatus)
        {
            var result = await _assignmentService.UpdateAssignmentStatus(assignmentId, newStatus);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("update-task")]
        public async Task<ActionResult<Assignment>> UpdateTask(int userId, int taskId, string detail, string desc, AssignStatus newStatus)
        {
            var updatedAssignment = await _assignmentService.UpdateTask(userId, taskId, detail, desc, newStatus);

            if (updatedAssignment == null)
            {
                return NotFound();
            }

            return Ok(updatedAssignment);
        }

        [HttpDelete("delete-task")]
        public async Task<ActionResult> DeleteTask(int taskId, int userId)
        {
            var result = await _assignmentService.DeleteTask(taskId, userId);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("assigned-tasks-to-departments")]
        public async Task<ActionResult<List<Assignment>>> AssignedTasksToDepartment(int userId)
        {
            var assignedTasks = await _assignmentService.AssignedTasksToDepartment(userId);
            return Ok(assignedTasks);
        }

        [HttpGet("my-profile")]
        public async Task<ActionResult<User>> MyProfile(int userId)
        {
            var userProfile = await _assignmentService.MyProfile(userId);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }*/
    }
}
