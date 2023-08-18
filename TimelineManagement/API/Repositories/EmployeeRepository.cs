using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(TimelineManagementDbContext context) : base(context) { }
    public bool isNotExist(string value)
    {
        return _context.Set<Employee>()
            .SingleOrDefault(e => e.Email.Contains(value) || e.PhoneNumber.Contains(value)) is null;
    }

    public string? Getlastnik()
    {
        var data = _context.Set<Employee>().OrderByDescending(e=>e.CreatedDate).FirstOrDefault()?.Nik;
        return data;
    }

    public Employee? GetByEmail(string email)
    {
        return _context.Set<Employee>().SingleOrDefault(e => e.Email.Contains(email));
    }

    public Employee? CheckEmail(string email)
    {
        return _context.Set<Employee>().FirstOrDefault(u => u.Email == email);
    }
}