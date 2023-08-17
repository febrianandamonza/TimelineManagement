using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineManagement.Models;

[Table("tb_tr_task_comments")]
public class TaskComment : BaseEntity
{
    [Column("description")]
    public string Description { get; set; }
    
    [Column("task_guid")]
    public Guid TaskGuid { get; set; }
    
    //Cardinality
    public Task? Task { get; set; }
}