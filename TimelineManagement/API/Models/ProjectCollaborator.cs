using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineManagement.Models;

[Table("tb_tr_project_collaborators")]
public class ProjectCollaborator : BaseEntity
{
    [Column("project_guid")]
    public Guid ProjectGuid { get; set; }
    
    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }
    
    //Cardinality
    public Employee? Employee { get; set; }
    public Project? Project { get; set; }
}