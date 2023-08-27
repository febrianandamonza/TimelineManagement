using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineManagement.Models;

[Table("tb_m_projects")]
public class Project : BaseEntity
{
    [Column("name", TypeName =("nvarchar(50)"))]
    public string Name { get; set; }
    
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }
    
    //Cardinality
    public Employee? Employee { get; set; }
    public ICollection<ProjectCollaborator>? ProjectCollaborator { get; set; }
    public ICollection<Task>? Task { get; set; }
    public ICollection<TaskComment>? TaskComment { get; set; }
    
}