using TimelineManagement.DTOs.Account;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace Client.Contracts
{
    public interface IProjectRepository : IRepository<Project, Guid>
    {
        Task<ResponseHandler<NewDefaultProjectDto>> Create(NewDefaultProjectDto newDefaultProjectDto);
    }
}
