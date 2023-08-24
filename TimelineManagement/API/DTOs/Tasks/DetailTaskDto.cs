using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.Tasks;

public class DetailTaskDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsFinished { get; set; }
    public PriorityLevel Priority { get; set; }
    public Guid ProjectGuid { get; set; }
    public string ProjectName { get; set; }
    public string ProjectManager { get; set; }
    public Guid SectionGuid { get; set; }
    public string SectionName { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeePhoneNumber { get; set; }
    public string EmployeeEmail { get; set; }
}