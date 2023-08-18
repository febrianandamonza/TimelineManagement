using System.ComponentModel.DataAnnotations.Schema;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.Models;

[Table("tb_tr_project_collaborators")]
public class ProjectCollaborator : BaseEntity
{
    [Column("status")] 
    public StatusLevel Status{ get; set; }
    
    [Column("project_guid")]
    public Guid ProjectGuid { get; set; }
    
    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }
    
    //Cardinality
    public Employee? Employee { get; set; }
    public Project? Project { get; set; }
}