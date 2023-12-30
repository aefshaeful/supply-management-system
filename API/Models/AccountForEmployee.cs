using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class AccountForEmployee : BaseEntity
    {
        public string Password { get; set; } = default!;

    }
}
