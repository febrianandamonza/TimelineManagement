using TimelineManagement.Contracts;
using TimelineManagement.DTOs.Tasks;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public IEnumerable<TaskDto> GetAll()
    {
        var tasks = _taskRepository.GetAll();
        if (!tasks.Any())
        {
            return Enumerable.Empty<TaskDto>();
        }

        var TaskDtos = new List<TaskDto>();
        foreach (var task in tasks)
        {
            TaskDtos.Add((TaskDto)task);
        }

        return TaskDtos;
    }

    public TaskDto? GetByGuid(Guid guid)
    {
        var task = _taskRepository.GetByGuid(guid);
        if (task is null)
        {
            return null;
        }

        return (TaskDto)task;
    }

    public TaskDto? Create(NewTaskDto newTaskDto)
    {
        var task = _taskRepository.Create(newTaskDto);
        if (task is null)
        {
            return null;
        }

        return (TaskDto)task;
    }

    public int Update(TaskDto TaskDto)
    {
        var task = _taskRepository.GetByGuid(TaskDto.Guid);
        if (task is null)
        {
            return -1;
        }

        Task toUpdate = TaskDto;
        toUpdate.CreatedDate = task.CreatedDate;
        var result = _taskRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var task = _taskRepository.GetByGuid(guid);
        if (task is null)
        {
            return -1;
        }

        var result = _taskRepository.Delete(task);
        return result ? 1
            : 0;
    }
}