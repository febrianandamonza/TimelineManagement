using TimelineManagement.Models;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class ProjectCollaboratorDto
{
    public Guid Guid { get; set; }
    public Guid ProjectGuid { get; set; }
    public Guid EmployeeGuid { get; set; }

    public static implicit operator ProjectCollaborator(ProjectCollaboratorDto projectCollaboratorDto)
    {
        return new ProjectCollaborator
        {
            Guid = projectCollaboratorDto.Guid,
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
            ProjectGuid = projectCollaborator.ProjectGuid,
            EmployeeGuid = projectCollaborator.EmployeeGuid
        };
    }
}