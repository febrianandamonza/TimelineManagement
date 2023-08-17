using TimelineManagement.Models;

namespace TimelineManagement.DTOs.Projects;

public class ProjectDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid EmployeeGuid { get; set; }


    public static implicit operator Project(ProjectDto projectDto)
    {
        return new Project
        {
            Guid = projectDto.Guid,
            Name = projectDto.Name,
            StartDate = projectDto.StartDate,
            EndDate = projectDto.EndDate,
            EmployeeGuid = projectDto.EmployeeGuid,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator ProjectDto(Project project)
    {
        return new ProjectDto
        {
            Guid = project.Guid,
            Name = project.Name,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            EmployeeGuid = project.EmployeeGuid
        };
    }
}