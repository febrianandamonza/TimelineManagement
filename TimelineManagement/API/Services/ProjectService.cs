using TimelineManagement.Contracts;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Models;

namespace TimelineManagement.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public IEnumerable<ProjectDto> GetAll()
    {
        var projects = _projectRepository.GetAll();
        if (!projects.Any())
        {
            return Enumerable.Empty<ProjectDto>();
        }

        var ProjectDtos = new List<ProjectDto>();
        foreach (var project in projects)
        {
            ProjectDtos.Add((ProjectDto)project);
        }

        return ProjectDtos;
    }

    public ProjectDto? GetByGuid(Guid guid)
    {
        var project = _projectRepository.GetByGuid(guid);
        if (project is null)
        {
            return null;
        }

        return (ProjectDto)project;
    }

    public ProjectDto? Create(NewProjectDto newProjectDto)
    {
        var project = _projectRepository.Create(newProjectDto);
        if (project is null)
        {
            return null;
        }

        return (ProjectDto)project;
    }

    public int Update(ProjectDto ProjectDto)
    {
        var project = _projectRepository.GetByGuid(ProjectDto.Guid);
        if (project is null)
        {
            return -1;
        }

        Project toUpdate = ProjectDto;
        toUpdate.CreatedDate = project.CreatedDate;
        var result = _projectRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var project = _projectRepository.GetByGuid(guid);
        if (project is null)
        {
            return -1;
        }

        var result = _projectRepository.Delete(project);
        return result ? 1
            : 0;
    }
}