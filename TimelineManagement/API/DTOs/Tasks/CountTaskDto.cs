namespace TimelineManagement.DTOs.Tasks;

public class CountTaskDto
{
    public Guid EmployeeGuid { get; set; }
    public int TotalTaskUnFinished { get; set; }
    public int TotalTaskFinished { get; set; }
    
}