using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class ProjectCollaboratorByProjectDto
{
    public Guid ProjectGuid { get; set; }
    public string ProjectName { get; set; }
    public DateTime ProjectStartDate { get; set; }
    public DateTime ProjectEndDate { get; set; }
    public Guid EmployeeGuid { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeEmail { get; set; }
    public StatusLevel Status { get; set; }
}