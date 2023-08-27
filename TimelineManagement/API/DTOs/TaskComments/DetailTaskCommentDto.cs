namespace TimelineManagement.DTOs.TaskComments;

public class DetailTaskCommentDto
{
    public Guid TaskGuid { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid ProjectGuid { get; set; }
    public string? Description { get; set; }
    public string EmployeeName { get; set; }
    public DateTime CreatedDateComment { get; set; }
    
}