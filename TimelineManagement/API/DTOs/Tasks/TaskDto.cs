using TimelineManagement.Utilities.Enums;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.DTOs.Tasks;

public class TaskDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsFinished { get; set; }
    public PriorityLevel Priority { get; set; }
    public Guid ProjectGuid { get; set; }
    public Guid SectionGuid { get; set; }
    public Guid EmployeeGuid { get; set; }

    public static implicit operator Task(TaskDto taskDto)
    {
        return new Task
        {
            Guid = taskDto.Guid,
            Name = taskDto.Name,
            StartDate = taskDto.StartDate,
            EndDate = taskDto.EndDate,
            IsFinished = taskDto.IsFinished,
            Priority = taskDto.Priority,
            ProjectGuid = taskDto.ProjectGuid,
            SectionGuid = taskDto.SectionGuid,
            EmployeeGuid = taskDto.EmployeeGuid,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator TaskDto(Task task)
    {
        return new TaskDto
        {
            Guid = task.Guid,
            Name = task.Name,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            IsFinished = task.IsFinished,
            Priority = task.Priority,
            ProjectGuid = task.ProjectGuid,
            SectionGuid = task.SectionGuid,
            EmployeeGuid = task.EmployeeGuid
        };
    }
}