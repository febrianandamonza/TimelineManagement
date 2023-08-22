using TimelineManagement.DTOs.Account;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Contracts
{
    public interface IProjectCollaboratorRepository : IRepository<ProjectCollaborator, Guid>
    {
        Task<ResponseHandler<NewProjectByEmployeeDto>> Create(NewProjectByEmployeeDto newProjectByEmployeeDto);
    }
}
