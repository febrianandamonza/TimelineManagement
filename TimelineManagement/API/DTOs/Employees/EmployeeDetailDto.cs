using TimelineManagement.Utilities.Enums;

namespace API.DTOs.Employees;

public class EmployeeDetailDto
{
    public Guid EmployeeGuid { get; set; }
    public string Nik { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderLevel Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Role { get; set; }
    public int TotalProject { get; set; }

}