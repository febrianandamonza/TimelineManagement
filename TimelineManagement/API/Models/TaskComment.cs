using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineManagement.Models;

[Table("tb_tr_task_comments")]
public class TaskComment : BaseEntity
{
    [Column("description")]
    public string Description { get; set; }
    
    [Column("task_guid")]
    public Guid TaskGuid { get; set; }
    [Column("project_guid")]
    public Guid ProjectGuid { get; set; }
    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }
    
    //Cardinality
    public Project? Project { get; set; }
    public Employee? Employee { get; set; }
    public Task? Task { get; set; }
}