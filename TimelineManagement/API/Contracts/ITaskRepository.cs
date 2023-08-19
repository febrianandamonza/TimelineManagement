using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Contracts;

public interface ITaskRepository : IGeneralRepository<Task>
{
    public Task? GetByName(string name);
}