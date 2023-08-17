using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TimelineManagement.Models;

[Table("tb_m_sections")]
public class Section
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }
    
    [Column("name", TypeName = ("nvarchar(50)"))]
    public string Name { get; set; }
    
    //Cardinality
    public ICollection<Task>? Task { get; set; }
}