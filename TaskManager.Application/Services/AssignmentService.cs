using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Application.IRepositories;
using TaskManager.Application.IServices;
using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUserRepository _userRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository, IUserRepository userRepository)
        {
            _assignmentRepository = assignmentRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateAssignmentResponse> CreateAssignment(CreateAssignmentRequest request)
        {
            try
            {
                var creator = await _userRepository.GetUserById(request.CreatorId);
                var assignee = await _userRepository.GetUserById(request.AssigneeId);
                var newAssignment = new Assignment
                {
                    Description = request.Description,
                    Details = request.Detail,
                    CreatorId = creator.UserId,
                    Creator = creator,
                    AssigneeId = assignee.UserId,
                    Assignee = assignee,
                    CreatedAt = DateTime.Now,
                    Status = AssignStatus.Created
                };

                await _assignmentRepository.CreateAssignment(newAssignment);

                return new CreateAssignmentResponse
                {
                    CreatedAssignment = newAssignment,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new CreateAssignmentResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<List<GetAllAssignmentsResponse>> GetAllAssignments()
        {
            var assignments = await _assignmentRepository.GetAllAssignments();
            var assignmentResponses = assignments.Select(a => new GetAllAssignmentsResponse
            {
                Creator = new UserResponse
                {
                    Name = a.Creator.UserName
                },
                Assignee = new UserResponse
                {
                    Name = a.Assignee.UserName,
                    Email = a.Assignee.Email,
                    Department = a.Assignee.Department
                },
                Description = a.Description,
                Status = (AssignStatusResponse)a.Status
            }).ToList();

            return assignmentResponses;
        }

        public async Task<GetDetailsResponse> GetAssignmentDetails(GetDetailsRequest request)
        {
            var assignment = await _assignmentRepository.GetAssignmentById(request.AssignmentId);

            if (assignment == null)
            {
                // Belirtilen görev bulunamadı
                return null;
            }

            var assignmentDetailResponse = new GetDetailsResponse
            {
                Id = assignment.Id,
                Description = assignment.Description,
                Details = assignment.Details,
                Assignee = new UserResponse
                {
                    UserId = assignment.Assignee.UserId,
                    Name = assignment.Assignee.UserName,
                    Email = assignment.Assignee.Email,
                    Department = assignment.Assignee.Department,
                    IsActive = assignment.Assignee.IsActive
                },
                Creator = new UserResponse
                {
                    UserId = assignment.Creator.UserId,
                    Name = assignment.Creator.UserName,
                    Email = assignment.Creator.Email,
                    Department = assignment.Creator.Department,
                    IsActive = assignment.Creator.IsActive
                },
                Status = (AssignStatusResponse)assignment.Status
            };

            return assignmentDetailResponse;
        }

        public async Task<UpdateAssignmentStatusResponse> UpdateAssignmentStatus(UpdateAssignmentStatusRequest request)
        {
            try
            {
                var assignment = await _assignmentRepository.GetAssignmentById(request.AssignmentId);

                if (assignment == null)
                {
                    return new UpdateAssignmentStatusResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Couldn't find Task."
                    };
                }

                assignment.Status = request.NewStatus;
                await _assignmentRepository.Update(assignment);

                return new UpdateAssignmentStatusResponse
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new UpdateAssignmentStatusResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequest request)
        {
            try
            {
                var assignment = await _assignmentRepository.GetAssignmentById(request.AssignmentId);

                if (assignment != null)
                {
                    assignment.Assignee = request.Assignee;
                    assignment.AssigneeId = request.Assignee.UserId;
                    assignment.Description = request.Description;
                    assignment.Details = request.Detail;
                    assignment.Status = request.NewStatus;

                    await _assignmentRepository.Update(assignment);

                    return new UpdateTaskResponse
                    {
                        UpdatedAssignment = assignment,
                        IsSuccess = true
                    };
                }

                return new UpdateTaskResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Assignment could not found"
                };
            }
            catch (Exception ex)
            {
                return new UpdateTaskResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Couldn't update: {ex.Message}"
                };
            }
        }
        public async Task<DeleteTaskResponse> DeleteTask(DeleteTaskRequest request)
        {
            try
            {
                var assignment = await _assignmentRepository.GetAssignmentById(request.TaskId);

                if (assignment != null && assignment.CreatorId == request.UserId)
                {
                    await _assignmentRepository.Delete(assignment);

                    return new DeleteTaskResponse
                    {
                        IsSuccess = true
                    };
                }

                return new DeleteTaskResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Couldn't find Task."
                };
            }
            catch (Exception ex)
            {
                return new DeleteTaskResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Error: {ex.Message}"
                };
            }
        }
        public async Task<AssignedTasksToDepartmentResponse> GetAssignedTasksToDepartment(AssignedTasksToDepartmentRequest request)
        {
            try
            {
                var userDepartment = request.Assignee.Department;

                if (userDepartment == null)
                {
                    return new AssignedTasksToDepartmentResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Couldn't find the department."
                    };
                }

                var assignedTasks = await _assignmentRepository.GetAssignmentsByDepartment(userDepartment);

                return new AssignedTasksToDepartmentResponse
                {
                    AssignedTasks = assignedTasks,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new AssignedTasksToDepartmentResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Error: {ex.Message}"
                };
            }
        }
    }
}
