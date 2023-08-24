using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class ProjectCollaboratorByEmployeeDto
{
    public Guid ProjectGuid { get; set; }
    public string ProjectName { get; set; }
    public Guid EmployeeGuid { get; set; }
    public string EmployeeEmail { get; set; }
    public StatusLevel Status { get; set; }
    
}