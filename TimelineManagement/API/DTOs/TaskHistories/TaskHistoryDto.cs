using TimelineManagement.Models;

namespace TimelineManagement.DTOs.TaskHistories;

public class TaskHistoryDto
{
    public Guid Guid { get; set; }
    public string? Description { get; set; }
    public Guid TaskGuid { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid ProjectGuid { get; set; }

    public static implicit operator TaskHistory(TaskHistoryDto taskHistoryDto)
    {
        return new TaskHistory
        {
            Guid = taskHistoryDto.Guid,
            Description = taskHistoryDto.Description,
            TaskGuid = taskHistoryDto.TaskGuid,
            EmployeeGuid = taskHistoryDto.EmployeeGuid,
            ProjectGuid = taskHistoryDto.ProjectGuid,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator TaskHistoryDto(TaskHistory taskHistory)
    {
        return new TaskHistoryDto
        {
            Guid = taskHistory.Guid,
            Description = taskHistory.Description,
            TaskGuid = taskHistory.TaskGuid,
            EmployeeGuid = taskHistory.EmployeeGuid,
            ProjectGuid = taskHistory.ProjectGuid
        };
    }
}