using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class ProjectRepository : GeneralRepository<Project>, IProjectRepository
{
    public ProjectRepository(TimelineManagementDbContext context) : base(context) { }
    public Project? GetByName(string name)
    {
        return _context.Set<Project>().FirstOrDefault(p => p.Name.Contains(name));
    }
    
}