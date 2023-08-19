using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Models;

namespace TimelineManagement.Services;

public class ProjectCollaboratorService
{
    private readonly IProjectCollaboratorRepository _projectCollaboratorRepository;

    public ProjectCollaboratorService(IProjectCollaboratorRepository projectCollaboratorRepository)
    {
        _projectCollaboratorRepository = projectCollaboratorRepository;
    }
    
    
    public int ChangeStatus(ChangeStatusDto changeStatusDto)
    {
        var projectcollab = _projectCollaboratorRepository.GetByGuid(changeStatusDto.Guid);
        if (projectcollab is null)
        {
            return -1;
        }

        var toUpdate = new ProjectCollaborator
        {
            Guid = projectcollab.Guid,
            Status = changeStatusDto.Status,
            ProjectGuid = projectcollab.ProjectGuid,
            EmployeeGuid = projectcollab.EmployeeGuid,
            CreatedDate = projectcollab.CreatedDate,
            ModifiedDate = DateTime.Now
        };
        
        var result = _projectCollaboratorRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }
    
    public IEnumerable<ProjectCollaboratorDto> GetAll()
    {
        var projectcollabs = _projectCollaboratorRepository.GetAll();
        if (!projectcollabs.Any())
        {
            return Enumerable.Empty<ProjectCollaboratorDto>();
        }

        var ProjectCollaboratorDtos = new List<ProjectCollaboratorDto>();
        foreach (var projectcollab in projectcollabs)
        {
            ProjectCollaboratorDtos.Add((ProjectCollaboratorDto)projectcollab);
        }

        return ProjectCollaboratorDtos;
    }

    public ProjectCollaboratorDto? GetByGuid(Guid guid)
    {
        var projectcollab = _projectCollaboratorRepository.GetByGuid(guid);
        if (projectcollab is null)
        {
            return null;
        }

        return (ProjectCollaboratorDto)projectcollab;
    }

    public ProjectCollaboratorDto? Create(NewProjectCollaboratorDto newProjectCollaboratorDto)
    {
        var projectcollab = _projectCollaboratorRepository.Create(newProjectCollaboratorDto);
        if (projectcollab is null)
        {
            return null;
        }

        return (ProjectCollaboratorDto)projectcollab;
    }

    public int Update(ProjectCollaboratorDto ProjectCollaboratorDto)
    {
        var projectcollab = _projectCollaboratorRepository.GetByGuid(ProjectCollaboratorDto.Guid);
        if (projectcollab is null)
        {
            return -1;
        }

        ProjectCollaborator toUpdate = ProjectCollaboratorDto;
        toUpdate.CreatedDate = projectcollab.CreatedDate;
        var result = _projectCollaboratorRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var projectcollab = _projectCollaboratorRepository.GetByGuid(guid);
        if (projectcollab is null)
        {
            return -1;
        }

        var result = _projectCollaboratorRepository.Delete(projectcollab);
        return result ? 1
            : 0;
    }
}