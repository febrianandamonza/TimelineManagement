using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.DTOs.Account;
using TimelineManagement.DTOs.AccountRoles;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ISectionRepository _sectionRepository;
    private readonly TimelineManagementDbContext _dbContext;

    public TaskService(ITaskRepository taskRepository, ISectionRepository sectionRepository, TimelineManagementDbContext dbContext)
    {
        _taskRepository = taskRepository;
        _sectionRepository = sectionRepository;
        _dbContext = dbContext;
    }
    
    public NewDefaultTaskDto CreateDefault(NewDefaultTaskDto newDefaultTaskDto)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var task = _taskRepository.Create( new Task
            {
                Guid = new Guid(),
                Name = newDefaultTaskDto.Name,
                StartDate = newDefaultTaskDto.StartDate,
                EndDate = newDefaultTaskDto.EndDate,
                Status = newDefaultTaskDto.Status,
                Priority = newDefaultTaskDto.Priority,
                ProjectGuid = newDefaultTaskDto.ProjectGuid,
                SectionGuid = Guid.Parse("fe4aa61c-329d-447f-811a-08db9fb220e4"),
                EmployeeGuid = newDefaultTaskDto.EmployeeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });
            
            var toDto = new NewDefaultTaskDto
            {
                Name = task.Name,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = task.Status,
                Priority = task.Priority,
                ProjectGuid = task.ProjectGuid,
                EmployeeGuid = newDefaultTaskDto.EmployeeGuid
            };
            
            transaction.Commit();
            return toDto;
        }
        catch 
        {
            transaction.Rollback();
            return null;
        }
    }
    
    
    public int ChangeSection(TaskChangeSection taskChangeSection)
    {
        var getTask = _taskRepository.GetByGuid(taskChangeSection.Guid);
        if (getTask is null)
        {
            return -1;
        }

        var task = new Task
        {
            Guid = getTask.Guid,
            Name = getTask.Name,
            StartDate = getTask.StartDate,
            EndDate = getTask.EndDate,
            Status = getTask.Status,
            Priority = getTask.Priority,
            ProjectGuid = getTask.ProjectGuid,
            SectionGuid = taskChangeSection.SectionGuid,
            EmployeeGuid = getTask.EmployeeGuid
        };

        var isUpdate = _taskRepository.Update(task);
        if (!isUpdate)
        {
            return 0;
        }

        return 1;
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