using TimelineManagement.Models;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class NewProjectCollaboratorDto
{
    public Guid ProjectGuid { get; set; }
    public Guid EmployeeGuid { get; set; }

    public static implicit operator ProjectCollaborator(NewProjectCollaboratorDto newProjectCollaboratorDto)
    {
        return new ProjectCollaborator
        {
            Guid = new Guid(),
            Status = 0,
            ProjectGuid = newProjectCollaboratorDto.ProjectGuid,
            EmployeeGuid = newProjectCollaboratorDto.EmployeeGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewProjectCollaboratorDto(ProjectCollaborator projectCollaborator)
    {
        return new NewProjectCollaboratorDto
        {
            ProjectGuid = projectCollaborator.ProjectGuid,
            EmployeeGuid = projectCollaborator.EmployeeGuid
        };
    }
}
