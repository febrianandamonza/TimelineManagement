using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Repositories;

public class    TaskRepository : GeneralRepository<Task>, ITaskRepository
{
    public TaskRepository(TimelineManagementDbContext context) : base(context) { }
    public Task? GetByName(string name)
    {
        return _context.Set<Task>().FirstOrDefault(t => t.Name.Contains(name));
    }
}