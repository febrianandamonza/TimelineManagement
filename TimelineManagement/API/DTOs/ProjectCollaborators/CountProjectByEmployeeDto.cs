namespace TimelineManagement.DTOs.ProjectCollaborators;

public class CountProjectByEmployeeDto
{
    public Guid EmployeeGuid { get; set; }
    public int Total { get; set; }
}