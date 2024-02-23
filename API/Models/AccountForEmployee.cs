using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_account_employees")]
    public class AccountForEmployee : BaseEntity
    {
        [Column("password", TypeName = "nvarchar(255)")]
        public string Password { get; set; } = default!;

        // Cardinality
        public Employee? Employee { get; set; }
        public ICollection<AccountRole>? AccountRoles { get; set; }

    }
}
