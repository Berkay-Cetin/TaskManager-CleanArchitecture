using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Requests;
using TaskManager.Application.DTOs.Responses;
using TaskManager.Domain;

namespace TaskManager.Application.IServices
{
    public interface IAssignmentService
    {
        Task<List<GetAllAssignmentsResponse>> GetAllAssignments();
        Task<GetDetailsResponse> GetAssignmentDetails(GetDetailsRequest request);
        Task<CreateAssignmentResponse> CreateAssignment(CreateAssignmentRequest request);
        Task<UpdateAssignmentStatusResponse> UpdateAssignmentStatus(UpdateAssignmentStatusRequest request);
        Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequest request);
        Task<DeleteTaskResponse> DeleteTask(DeleteTaskRequest request);
        Task<AssignedTasksToDepartmentResponse> GetAssignedTasksToDepartment(AssignedTasksToDepartmentRequest request);
    }
}
