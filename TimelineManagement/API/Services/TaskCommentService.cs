using TimelineManagement.Contracts;
using TimelineManagement.Models;
using TimelineManagement.DTOs.TaskComments;

namespace TimelineManagement.Services;

public class TaskCommentService
{
    private readonly ITaskCommentRepository _taskCommentRepository;

    public TaskCommentService(ITaskCommentRepository taskCommentRepository)
    {
        _taskCommentRepository = taskCommentRepository;
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