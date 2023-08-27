using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.Repositories;

public class ProjectCollaboratorRepository : GeneralRepository<ProjectCollaborator>, IProjectCollaboratorRepository
{
    public ProjectCollaboratorRepository(TimelineManagementDbContext context) : base(context) { }
    public ProjectCollaborator? isExist(Guid guid, Guid projectGuid)
    {
        return _context.Set<ProjectCollaborator>().SingleOrDefault(tc => tc.EmployeeGuid.Equals(guid) && tc.Status == StatusLevel.Waiting && tc.ProjectGuid == projectGuid);
    }
    public ProjectCollaborator? isAccepted(Guid guid, Guid projectGuid)
    {
        return _context.Set<ProjectCollaborator>().SingleOrDefault(tc => tc.EmployeeGuid.Equals(guid)  && tc.Status == StatusLevel.Accepted && tc.ProjectGuid == projectGuid);
    }
}