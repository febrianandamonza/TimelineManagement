using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.Services;

public class ProjectCollaboratorService
{
    private readonly IProjectCollaboratorRepository _projectCollaboratorRepository;
    private readonly IEmployeeRepository _employeeRepository;
    
    private readonly TimelineManagementDbContext _dbContext;
    private readonly IProjectRepository _projectRepository;

    public ProjectCollaboratorService(IProjectCollaboratorRepository projectCollaboratorRepository, TimelineManagementDbContext dbContext, IEmployeeRepository employeeRepository, IProjectRepository projectRepository)
    {
        _projectCollaboratorRepository = projectCollaboratorRepository;
        _dbContext = dbContext;
        _employeeRepository = employeeRepository;
        _projectRepository = projectRepository;
    }
    
    public IEnumerable<ProjectCollaboratorWaitingDto> GetAllProjectCollaboratorIsWaitingByEmployee(Guid guid)
    {
        var result = from pc in _projectCollaboratorRepository.GetAll() where pc.Status is StatusLevel.Waiting
            join employee in _employeeRepository.GetAll() on pc.EmployeeGuid equals employee.Guid where employee.Guid == guid
            join project in _projectRepository.GetAll() on pc.ProjectGuid equals project.Guid
            select new ProjectCollaboratorWaitingDto
            {
                Guid = pc.Guid,
                Status = pc.Status,
                ProjectGuid = pc.ProjectGuid,
                ProjectName = project.Name,
                EmployeeGuid = pc.EmployeeGuid,
                EmployeeName = employee.FirstName + employee.LastName
            };
        return result;

    }
    
    public IEnumerable<ProjectCollaboratorByEmployeeDto> GetAllProjectCollaboratorByEmployee(Guid guid)
    {
        var result = from pc in _projectCollaboratorRepository.GetAll() where pc.Status is StatusLevel.Accepted
            join employee in _employeeRepository.GetAll() on pc.EmployeeGuid equals employee.Guid where employee.Guid == guid
            join project in _projectRepository.GetAll() on pc.ProjectGuid equals project.Guid
            select new ProjectCollaboratorByEmployeeDto
            {
                ProjectGuid = pc.ProjectGuid,
                ProjectName = project.Name,
                ProjectStartDate = project.StartDate,
                ProjectEndDate = project.EndDate,
                EmployeeGuid = pc.EmployeeGuid,
                EmployeeEmail = employee.Email,
                Status = pc.Status
            };
        return result;

    }
    
    public NewProjectByEmployeeDto? CreateByEmail(NewProjectByEmployeeDto newProjectByEmployeeDto)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var employee = _employeeRepository.GetByEmail(newProjectByEmployeeDto.Email);
            if (employee is null)
            {
                return null;
            }

            var projectCollab = _projectCollaboratorRepository.Create(new ProjectCollaborator
            {
                Guid = new Guid(),
                ProjectGuid = newProjectByEmployeeDto.ProjectGuid,
                EmployeeGuid = employee.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Status = 0
            });

            
            var toDto = new NewProjectByEmployeeDto
            {
                ProjectGuid = projectCollab.ProjectGuid,
                Email = employee.Email
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