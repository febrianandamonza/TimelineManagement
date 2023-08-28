namespace TimelineManagement.DTOs.TaskHistories;

public class DetailTaskHistoryDto
{
    public Guid TaskGuid { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid ProjectGuid { get; set; }
    public string? Description { get; set; }
    public string EmployeeName { get; set; }
    public DateTime CreatedDateHistory { get; set; }
    
}