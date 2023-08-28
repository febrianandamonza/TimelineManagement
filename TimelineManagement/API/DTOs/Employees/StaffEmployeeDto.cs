using TimelineManagement.Utilities.Enums;

namespace API.DTOs.Employees;

public class StaffEmployeeDto
{
    public Guid EmployeeGuid { get; set; }
    public string FullName { get; set; }
    
    public DateTime BirthDate { get; set; }
    public GenderLevel Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}