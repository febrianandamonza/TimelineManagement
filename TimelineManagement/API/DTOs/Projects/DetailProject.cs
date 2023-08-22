using Microsoft.Build.Evaluation;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.Projects;

public class DetailProject
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid TaskGuid { get; set; }
    public string TaskName { get; set; }

    public PriorityLevel Priority { get; set; }
    public DateTime StartDateTask { get; set; }
    public DateTime EndDateTask { get; set; }
    public Guid TaskSection { get; set; }
}