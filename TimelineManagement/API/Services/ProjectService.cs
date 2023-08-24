using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Enums;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectCollaboratorRepository _projectCollaboratorRepository;
    private readonly ISectionRepository _sectionRepository;
    
    private readonly TimelineManagementDbContext _dbContext;

    public ProjectService(IProjectRepository projectRepository, ITaskRepository taskRepository, TimelineManagementDbContext dbContext, IProjectCollaboratorRepository projectCollaboratorRepository, ISectionRepository sectionRepository)
    {
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
        _dbContext = dbContext;
        _projectCollaboratorRepository = projectCollaboratorRepository;
        _sectionRepository = sectionRepository;
    }
    
    
    public IEnumerable<DetailProject>?  GetALlDetailProjectsByGuid(Guid guid)
    {
        var result = from p in _projectRepository.GetAll() where p.Guid == guid
            join t in _taskRepository.GetAll() on p.Guid equals t.ProjectGuid
            select new DetailProject
            {
                Guid = p.Guid,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.StartDate,
                EmployeeGuid = p.EmployeeGuid,
                TaskGuid = t.Guid,
                TaskName = t.Name,
                Priority = t.Priority,
                StartDateTask = t.StartDate,
                EndDateTask = t.EndDate,
                TaskSection = t.SectionGuid
            };
        
        return result;
    }
    
    public IEnumerable<ProjectByEmployeeDto>?  GetAllByEmployeeGuid(Guid guid)
    {
        var result = from project in _projectRepository.GetAll()
            where project.EmployeeGuid == guid
            select new ProjectByEmployeeDto
            {
                Guid = project.Guid,
                ProjectName = project.Name
            };
        
        return result;
    }
    
    public NewDefaultProjectDto? CreateProject(NewDefaultProjectDto newDefaultProjectDto)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var project = _projectRepository.Create(new Project
            {
                Guid = new Guid(),
                Name = newDefaultProjectDto.Name,
                StartDate = newDefaultProjectDto.StartDate,
                EndDate = newDefaultProjectDto.EndDate,
                EmployeeGuid = newDefaultProjectDto.EmployeeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });
            
            var task = _taskRepository.Create(new Task
            { 
                Guid = new Guid(),
                Name = newDefaultProjectDto.TaskName,
                StartDate = newDefaultProjectDto.StartDateTask,
                EndDate = newDefaultProjectDto.EndDateTask,
                IsFinished = false,
                Priority = newDefaultProjectDto.Priority,
                ProjectGuid = project.Guid,
                SectionGuid = Guid.Parse("fe4aa61c-329d-447f-811a-08db9fb220e4"),
                EmployeeGuid = project.EmployeeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
                
            });

            var projectCollab = _projectCollaboratorRepository.Create(new ProjectCollaborator
            {
                Guid = new Guid(),
                ProjectGuid = project.Guid,
                EmployeeGuid = newDefaultProjectDto.EmployeeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Status = StatusLevel.Accepted
            });
            
            var toDto = new NewDefaultProjectDto
            {
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                EmployeeGuid = project.EmployeeGuid,
                TaskName = task.Name,
                Priority = task.Priority,
                StartDateTask = task.StartDate,
                EndDateTask = task.EndDate
                
            };
            
            transaction.Commit();
            return toDto;
        }
        catch 
        {
            transaction.Rollback();
            return null;
        }
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