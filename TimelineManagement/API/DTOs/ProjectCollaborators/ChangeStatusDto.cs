using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.DTOs.ProjectCollaborators;

public class ChangeStatusDto
{
    public Guid Guid { get; set; }
    public StatusLevel Status { get; set; }
}