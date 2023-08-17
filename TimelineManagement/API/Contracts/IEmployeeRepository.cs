using TimelineManagement.Models;

namespace TimelineManagement.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    public bool isNotExist(string value);
    public string? Getlastnik();
}