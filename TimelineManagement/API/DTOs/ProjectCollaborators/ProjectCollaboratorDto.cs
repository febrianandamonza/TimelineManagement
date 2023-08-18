using TimelineManagement.Models;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class ProjectCollaboratorDto
{
    public Guid Guid { get; set; }
    public StatusLevel Status { get; set; }
    public Guid ProjectGuid { get; set; }
    public Guid EmployeeGuid { get; set; }

    public static implicit operator ProjectCollaborator(ProjectCollaboratorDto projectCollaboratorDto)
    {
        return new ProjectCollaborator
        {
            Guid = projectCollaboratorDto.Guid,
            Status = projectCollaboratorDto.Status,
            ProjectGuid = projectCollaboratorDto.ProjectGuid,
            EmployeeGuid = projectCollaboratorDto.EmployeeGuid,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator ProjectCollaboratorDto(ProjectCollaborator projectCollaborator)
    {
        return new ProjectCollaboratorDto
        {
            Guid = projectCollaborator.Guid,
            Status = projectCollaborator.Status,
            ProjectGuid = projectCollaborator.ProjectGuid,
            EmployeeGuid = projectCollaborator.EmployeeGuid
        };
    }
}