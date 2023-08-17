using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineManagement.Models;

[Table("tb_m_accounts")]
public class Account : BaseEntity
{
    [Column("password", TypeName = ("nvarchar(200)"))]
    public string Password { get; set; }
    [Column("otp")]
    public int Otp { get; set; }
    [Column("is_used")]
    public bool IsUsed { get; set; }
    
    [Column("expired_date")]
    public DateTime ExpiredDate { get; set; }

    //Cardinality
    public Employee? Employee { get; set; }
    public IEnumerable<AccountRole> AccountRole { get; set; }
}