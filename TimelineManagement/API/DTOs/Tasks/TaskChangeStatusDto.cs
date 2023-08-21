using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.Tasks;

public class TaskChangeStatusDto
{
    public Guid Guid { get; set; }
    public bool IsFinished { get; set; }
}