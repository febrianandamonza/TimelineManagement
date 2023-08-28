using System.ComponentModel.DataAnnotations.Schema;
using TimelineManagement.Utilities.Enums;

namespace TimelineManagement.Models;

[Table("tb_m_tasks")]
public class Task : BaseEntity
{
    [Column("name",TypeName = ("nvarchar(50)"))]
    public string Name { get; set; }
    
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    [Column("is_finished")]
    public bool IsFinished { get; set; }
    
    [Column("priority")]
    public PriorityLevel Priority { get; set; }
    
    [Column("project_guid")]
    public Guid ProjectGuid { get; set; }
    
    [Column("section_guid")]
    public Guid SectionGuid { get; set; }
    
    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }
    
    //Cardinality
    public Section? Section { get; set; }
    public Project? Project { get; set; }
    public Employee? Employee { get; set; }
    public ICollection<TaskComment>? TaskComment { get; set; }
    public ICollection<TaskHistory>? TaskHistory { get; set; }
}