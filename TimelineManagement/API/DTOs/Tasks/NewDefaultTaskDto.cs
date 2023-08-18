using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.Tasks;

public class NewDefaultTaskDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Status { get; set; }
    public PriorityLevel Priority { get; set; }
    public Guid ProjectGuid { get; set; }
    public Guid EmployeeGuid { get; set; }

}