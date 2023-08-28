using TimelineManagement.Models;

namespace TimelineManagement.DTOs.TaskHistories;

public class NewTaskHistoryDto
{
    public string? Description { get; set; }
    public Guid TaskGuid { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid ProjectGuid { get; set; }

    public static implicit operator TaskHistory(NewTaskHistoryDto newTaskHistoryDto)
    {
        return new TaskHistory
        {
            Guid = new Guid(),
            Description = newTaskHistoryDto.Description,
            TaskGuid = newTaskHistoryDto.TaskGuid,
            EmployeeGuid = newTaskHistoryDto.EmployeeGuid,
            ProjectGuid = newTaskHistoryDto.ProjectGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewTaskHistoryDto(TaskHistory taskHistory)
    {
        return new NewTaskHistoryDto
        {
            Description = taskHistory.Description,
            TaskGuid = taskHistory.TaskGuid,
            EmployeeGuid = taskHistory.EmployeeGuid,
            ProjectGuid = taskHistory.ProjectGuid
        };
    }
}