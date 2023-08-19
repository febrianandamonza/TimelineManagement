using API.DTOs.Employees;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.Contracts;
using TimelineManagement.DTOs.Employees;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IProjectRepository projectRepository, IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository)
    {
        _employeeRepository = employeeRepository;
        _projectRepository = projectRepository;
        _accountRepository = accountRepository;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
    }
    
    public IEnumerable<EmployeeDto> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        if (!employees.Any())
        {
            return Enumerable.Empty<EmployeeDto>();
        }

        var employeeDtos = new List<EmployeeDto>();
        foreach (var employee in employees)
        {
            employeeDtos.Add((EmployeeDto)employee);
        }

        return employeeDtos;
    }

    public EmployeeDto? GetByGuid(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }

        return (EmployeeDto)employee;
    }

    public IEnumerable<EmployeeDetailDto> GetAllEmployeeDetail()
    {
        var result = from employee in _employeeRepository.GetAll()
                     join account in _accountRepository.GetAll() on employee.Guid equals account.Guid
                     join accountRole in _accountRoleRepository.GetAll() on account.Guid equals accountRole.AccountGuid
                     join role in _roleRepository.GetAll() on accountRole.RoleGuid equals role.Guid
                     join project in _projectRepository.GetAll() on employee.Guid equals project.EmployeeGuid into employeeProjects
                     select new EmployeeDetailDto
                     {
                         EmployeeGuid = employee.Guid,
                         Nik = employee.Nik,
                         FullName = employee.FirstName + " " + employee.LastName,
                         BirthDate = employee.BirthDate,
                         Gender = employee.Gender,
                         HiringDate = employee.HiringDate,
                         Email = employee.Email,
                         PhoneNumber = employee.PhoneNumber,
                         Role = role.Name,
                         TotalProject = employeeProjects.Count()
                     };

        return result;

    }
    public EmployeeDetailDto? GetEmployeeDetailByGuid(Guid guid)
    {
        return GetAllEmployeeDetail().SingleOrDefault(e => e.EmployeeGuid == guid);
    }

    public IEnumerable<StaffEmployeeDto> GetStaffEmployees()
    {
        var result = from employee in _employeeRepository.GetAll()
                             join account in _accountRepository.GetAll() on employee.Guid equals account.Guid
                             join accountRole in _accountRoleRepository.GetAll() on account.Guid equals accountRole.AccountGuid
                             join role in _roleRepository.GetAll() on accountRole.RoleGuid equals role.Guid
                             where role.Name == "Staff"
                             select new StaffEmployeeDto
                             {
                                 FullName = employee.FirstName + " " + employee.LastName,
                                 EmployeeGuid = employee.Guid
                             };

        return result;
    }

    public EmployeeDto? Create(NewEmployeeDto newEmployeeDto)
    {
        Employee toCreate = newEmployeeDto;
        toCreate.Nik = GenerateHandler.Nik(_employeeRepository.Getlastnik());
        
        var employee = _employeeRepository.Create(toCreate);
        if (employee is null)
        {
            return null;
        }

        return (EmployeeDto)employee;
    }

    public int Update(EmployeeDto employeeDto)
    {
        var employee = _employeeRepository.GetByGuid(employeeDto.Guid);
        if (employee is null)
        {
            return -1;
        }

        Employee toUpdate = employeeDto;
        toUpdate.CreatedDate = employee.CreatedDate;
        var result = _employeeRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return -1;
        }

        var result = _employeeRepository.Delete(employee);
        return result ? 1 
            : 0;
    }

}