using TimelineManagement.Models;

namespace TimelineManagement.Contracts;

public interface IRoleRepository : IGeneralRepository<Role>
{
    public Role? GetByName(string name);
}