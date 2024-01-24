using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_employees")]
    public class Employee : BaseEntity
    {
        [Column("first_name", TypeName = "nvarchar(255)")]   
        public string FirstName { get; set; } = default!;

        [Column("last_name", TypeName = "nvarchar(255)")]
        public string LastName { get; set; } = default!;

        [Column("email", TypeName = "nvarchar(100)")]
        public string Email { get; set; } = default!;


        // Cardinality
        [ForeignKey("Guid")]
        public AccountForEmployee? AccountForEmployee { get; set; }

    }
}
