using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class AccountRole
    {
        public Guid AccountGuid { get; set; }

        public Guid RoleGuid { get; set; }
    }
}
