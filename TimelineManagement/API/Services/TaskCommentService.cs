using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;
using TimelineManagement.DTOs.TaskComments;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.Services;

public class TaskCommentService
{
    private readonly ITaskCommentRepository _taskCommentRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly TimelineManagementDbContext _dbContext;

    public TaskCommentService(ITaskCommentRepository taskCommentRepository, ITaskRepository taskRepository, IEmployeeRepository employeeRepository, TimelineManagementDbContext dbContext, IProjectRepository projectRepository)
    {
        _taskCommentRepository = taskCommentRepository;
        _taskRepository = taskRepository;
        _employeeRepository = employeeRepository;
        _dbContext = dbContext;
        _projectRepository = projectRepository;
    }
    
    public CountComment? CountComment(Guid taskGuid, Guid projectGuid)
    {
        var getTaskComment = _taskCommentRepository.GetAll().Count(tc => tc.TaskGuid == taskGuid && tc.ProjectGuid == projectGuid);

        var result = new CountComment{
            TaskGuid = taskGuid,
            ProjectGuid = projectGuid,
            Total = getTaskComment
        };
        return result;

    }
    
    public IEnumerable<DetailTaskCommentDto>?  DetailTaskComment(Guid taskGuid, Guid projectGuid)
    {
        var result = from tc in _taskCommentRepository.GetAll() orderby tc.CreatedDate descending 
            join project in _projectRepository.GetAll() on tc.ProjectGuid equals project.Guid
            where project.Guid == projectGuid
            join task in _taskRepository.GetAll() on tc.TaskGuid equals task.Guid where task.Guid == taskGuid
            join employee in _employeeRepository.GetAll() on tc.EmployeeGuid equals employee.Guid
            select new DetailTaskCommentDto
            {
                TaskGuid = task.Guid,
                EmployeeGuid = employee.Guid,
                ProjectGuid = project.Guid,
                Description = tc.Description,
                EmployeeName = employee.FirstName + " " + employee.LastName,
                CreatedDateComment = tc.CreatedDate
            };
        
        return result;
    }
    
    public IEnumerable<TaskCommentDto> GetAll()
    {
        var taskcomments = _taskCommentRepository.GetAll();
        if (!taskcomments.Any())
        {
            return Enumerable.Empty<TaskCommentDto>();
        }

        var TaskCommentDtos = new List<TaskCommentDto>();
        foreach (var taskcomment in taskcomments)
        {
            TaskCommentDtos.Add((TaskCommentDto)taskcomment);
        }

        return TaskCommentDtos;
    }

    public TaskCommentDto? GetByGuid(Guid guid)
    {
        var taskcomment = _taskCommentRepository.GetByGuid(guid);
        if (taskcomment is null)
        {
            return null;
        }

        return (TaskCommentDto)taskcomment;
    }

    public TaskCommentDto? Create(NewTaskCommentDto newTaskCommentDto)
    {
        var taskcomment = _taskCommentRepository.Create(newTaskCommentDto);
        if (taskcomment is null)
        {
            return null;
        }

        return (TaskCommentDto)taskcomment;
    }

    public int Update(TaskCommentDto TaskCommentDto)
    {
        var taskcomment = _taskCommentRepository.GetByGuid(TaskCommentDto.Guid);
        if (taskcomment is null)
        {
            return -1;
        }

        TaskComment toUpdate = TaskCommentDto;
        toUpdate.CreatedDate = taskcomment.CreatedDate;
        var result = _taskCommentRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var taskcomment = _taskCommentRepository.GetByGuid(guid);
        if (taskcomment is null)
        {
            return -1;
        }

        var result = _taskCommentRepository.Delete(taskcomment);
        return result ? 1
            : 0;
    }
}