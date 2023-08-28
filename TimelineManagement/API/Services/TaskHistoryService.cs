using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.DTOs.TaskHistories;
using TimelineManagement.Models;

namespace TimelineManagement.Services;

public class TaskHistoryService
{
    private readonly ITaskHistoryRepository _taskHistoryRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly TimelineManagementDbContext _dbContext;

    public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository, ITaskRepository taskRepository, IEmployeeRepository employeeRepository, TimelineManagementDbContext dbContext, IProjectRepository projectRepository)
    {
        _taskHistoryRepository = taskHistoryRepository;
        _taskRepository = taskRepository;
        _employeeRepository = employeeRepository;
        _dbContext = dbContext;
        _projectRepository = projectRepository;
    }
    
    public IEnumerable<DetailTaskHistoryDto>?  DetailTaskHistory(Guid taskGuid, Guid projectGuid)
    {
        var result = from tc in _taskHistoryRepository.GetAll() orderby tc.CreatedDate descending 
            join project in _projectRepository.GetAll() on tc.ProjectGuid equals project.Guid
            where project.Guid == projectGuid
            join task in _taskRepository.GetAll() on tc.TaskGuid equals task.Guid where task.Guid == taskGuid
            join employee in _employeeRepository.GetAll() on tc.EmployeeGuid equals employee.Guid
            select new DetailTaskHistoryDto
            {
                TaskGuid = task.Guid,
                EmployeeGuid = employee.Guid,
                ProjectGuid = project.Guid,
                Description = tc.Description,
                EmployeeName = employee.FirstName + " " + employee.LastName,
                CreatedDateHistory = tc.CreatedDate
            };
        
        return result;
    }
    
    public IEnumerable<TaskHistoryDto> GetAll()
    {
        var taskhistories = _taskHistoryRepository.GetAll();
        if (!taskhistories.Any())
        {
            return Enumerable.Empty<TaskHistoryDto>();
        }

        var taskHistoryDtos = new List<TaskHistoryDto>();
        foreach (var taskHistory in taskhistories)
        {
            taskHistoryDtos.Add((TaskHistoryDto)taskHistory);
        }

        return taskHistoryDtos;
    }

    public TaskHistoryDto? GetByGuid(Guid guid)
    {
        var taskHistory = _taskHistoryRepository.GetByGuid(guid);
        if (taskHistory is null)
        {
            return null;
        }

        return (TaskHistoryDto)taskHistory;
    }

    public TaskHistoryDto? Create(NewTaskHistoryDto newtaskHistoryDto)
    {
        var taskHistory = _taskHistoryRepository.Create(newtaskHistoryDto);
        if (taskHistory is null)
        {
            return null;
        }

        return (TaskHistoryDto)taskHistory;
    }

    public int Update(TaskHistoryDto taskHistoryDto)
    {
        var taskHistory = _taskHistoryRepository.GetByGuid(taskHistoryDto.Guid);
        if (taskHistory is null)
        {
            return -1;
        }

        TaskHistory toUpdate = taskHistoryDto;
        toUpdate.CreatedDate = taskHistory.CreatedDate;
        var result = _taskHistoryRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var taskHistory = _taskHistoryRepository.GetByGuid(guid);
        if (taskHistory is null)
        {
            return -1;
        }

        var result = _taskHistoryRepository.Delete(taskHistory);
        return result ? 1
            : 0;
    }
}