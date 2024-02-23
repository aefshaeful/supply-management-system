using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_account_vendors")]
    public class AccountForVendor : BaseEntity
    {
        [Column("password", TypeName = "nvarchar(255)")]
        public string Password { get; set; } = default!;

        // Cardinality
        public Vendor? Vendor { get; set; }
    }
}
