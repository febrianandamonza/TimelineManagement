using TimelineManagement.Models;

namespace TimelineManagement.DTOs.TaskComments;

public class TaskCommentDto
{
    public Guid Guid { get; set; }
    public string? Description { get; set; }
    public Guid TaskGuid { get; set; }
    
    public Guid EmployeeGuid { get; set; }
    public Guid ProjectGuid { get; set; }

    public static implicit operator TaskComment(TaskCommentDto taskCommentDto)
    {
        return new TaskComment
        {
            Guid = taskCommentDto.Guid,
            Description = taskCommentDto.Description,
            TaskGuid = taskCommentDto.TaskGuid,
            EmployeeGuid = taskCommentDto.EmployeeGuid,
            ProjectGuid = taskCommentDto.ProjectGuid,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator TaskCommentDto(TaskComment taskComment)
    {
        return new TaskCommentDto
        {
            Guid = taskComment.Guid,
            Description = taskComment.Description,
            TaskGuid = taskComment.TaskGuid,
            EmployeeGuid = taskComment.EmployeeGuid,
            ProjectGuid = taskComment.ProjectGuid
        };
    }
}