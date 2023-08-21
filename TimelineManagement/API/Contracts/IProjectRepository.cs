using TimelineManagement.Models;

namespace TimelineManagement.Contracts;

public interface IProjectRepository : IGeneralRepository<Project>
{
    public Project? GetByName(string name);
    
}