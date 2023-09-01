using System.Security.Principal;
using TimelineManagement.Models;

namespace TimelineManagement.DTOs.Projects;

public class NewProjectDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid EmployeeGuid { get; set; }

    public static implicit operator Project(NewProjectDto newProjectDto)
    {
        return new Project
        {
            Guid = new Guid(),
            Name = newProjectDto.Name,
            IsDeleted = false,
            StartDate = newProjectDto.StartDate,
            EndDate = newProjectDto.EndDate,
            EmployeeGuid = newProjectDto.EmployeeGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewProjectDto(Project project)
    {
        return new NewProjectDto
        {
            Name = project.Name,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            EmployeeGuid = project.EmployeeGuid
        };
    }
}