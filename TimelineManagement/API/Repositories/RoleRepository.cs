using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class RoleRepository : GeneralRepository<Role>, IRoleRepository
{
    public RoleRepository(TimelineManagementDbContext context) : base(context) { }
    public Role? GetByName(string name)
    {
        return _context.Set<Role>().SingleOrDefault(r => r.Name.Contains(name));
    }
}