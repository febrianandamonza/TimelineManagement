using TimelineManagement.Models;

namespace TimelineManagement.DTOs.TaskComments;

public class TaskCommentDto
{
    public Guid Guid { get; set; }
    public string? Description { get; set; }
    public Guid TaskGuid { get; set; }

    public static implicit operator TaskComment(TaskCommentDto taskCommentDto)
    {
        return new TaskComment
        {
            Guid = taskCommentDto.Guid,
            Description = taskCommentDto.Description,
            TaskGuid = taskCommentDto.TaskGuid,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator TaskCommentDto(TaskComment taskComment)
    {
        return new TaskCommentDto
        {
            Guid = taskComment.Guid,
            Description = taskComment.Description,
            TaskGuid = taskComment.TaskGuid
        };
    }
}