using TimelineManagement.Utilities.Enums;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.DTOs.Tasks;

public class NewTaskDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsFinished { get; set; }
    public PriorityLevel Priority { get; set; }
    public Guid ProjectGuid { get; set; }
    public Guid SectionGuid { get; set; }
    public Guid EmployeeGuid { get; set; }

    public static implicit operator Task(NewTaskDto newTaskDto)
    {
        return new Task
        {
            Guid = new Guid(),
            Name = newTaskDto.Name,
            StartDate = newTaskDto.StartDate,
            EndDate = newTaskDto.EndDate,
            IsFinished = newTaskDto.IsFinished,
            Priority = newTaskDto.Priority,
            ProjectGuid = newTaskDto.ProjectGuid,
            SectionGuid = newTaskDto.SectionGuid,
            EmployeeGuid = newTaskDto.EmployeeGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewTaskDto(Task task)
    {
        return new NewTaskDto
        {
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