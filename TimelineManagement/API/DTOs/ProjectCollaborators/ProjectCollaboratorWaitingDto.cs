using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class ProjectCollaboratorWaitingDto
{
    public Guid Guid { get; set; }
    public StatusLevel Status { get; set; }
    public Guid ProjectGuid { get; set; }
    public string ProjectName { get; set; }
    public Guid EmployeeGuid { get; set; }
    public string EmployeeName { get; set; }
}