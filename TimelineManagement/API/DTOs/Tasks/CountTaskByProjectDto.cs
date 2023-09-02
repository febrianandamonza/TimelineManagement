namespace TimelineManagement.DTOs.Tasks;

public class CountTaskByProjectDto
{
    public Guid ProjectGuid { get; set; }
    public int TotalTaskUnFinished { get; set; }
    public int TotalTaskFinished { get; set; }
}