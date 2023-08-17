using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class ProjectCollaboratorRepository : GeneralRepository<ProjectCollaborator>, IProjectCollaboratorRepository
{
    public ProjectCollaboratorRepository(TimelineManagementDbContext context) : base(context) { }
}