using TimelineManagement.Models;

namespace TimelineManagement.DTOs.TaskComments;

public class NewTaskCommentDto
{
    public string? Description { get; set; }
    public Guid TaskGuid { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid ProjectGuid { get; set; }

    public static implicit operator TaskComment(NewTaskCommentDto newTaskCommentDto)
    {
        return new TaskComment
        {
            Guid = new Guid(),
            Description = newTaskCommentDto.Description,
            TaskGuid = newTaskCommentDto.TaskGuid,
            EmployeeGuid = newTaskCommentDto.EmployeeGuid,
            ProjectGuid = newTaskCommentDto.ProjectGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewTaskCommentDto(TaskComment taskComment)
    {
        return new NewTaskCommentDto
        {
            Description = taskComment.Description,
            TaskGuid = taskComment.TaskGuid,
            EmployeeGuid = taskComment.EmployeeGuid,
            ProjectGuid = taskComment.ProjectGuid
        };
    }
}