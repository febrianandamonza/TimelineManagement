using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.Tasks;

public class NewDefaultTaskDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public PriorityLevel Priority { get; set; }
    public string ProjectName { get; set; }
    public string EmployeeEmail { get; set; }

}