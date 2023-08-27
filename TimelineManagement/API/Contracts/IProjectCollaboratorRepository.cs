using TimelineManagement.Models;

namespace TimelineManagement.Contracts;

public interface IProjectCollaboratorRepository : IGeneralRepository<ProjectCollaborator>
{
    public ProjectCollaborator? isExist(Guid guid, Guid projectGuid);
    public ProjectCollaborator? isAccepted(Guid guid, Guid projectGuid);
}