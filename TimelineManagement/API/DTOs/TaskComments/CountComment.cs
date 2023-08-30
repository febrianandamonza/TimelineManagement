namespace TimelineManagement.DTOs.TaskComments;

public class CountComment
{
    public Guid TaskGuid { get; set; }
    public Guid ProjectGuid { get; set; }
    public int Total { get; set; }
}