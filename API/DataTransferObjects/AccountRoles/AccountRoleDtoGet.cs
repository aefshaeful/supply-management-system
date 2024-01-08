using API.Models;

namespace API.DataTransferObjects.AccountRoles
{
    public class AccountRoleDtoGet
    {
        public Guid Guid { get; set; }
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }

        // implicit operator
        public static implicit operator AccountRole(AccountRoleDtoGet dto)
        {
            return new AccountRole
            {
                Guid = dto.Guid,
                AccountGuid = dto.AccountGuid,
                RoleGuid = dto.RoleGuid
            };
        }

        // explicit operator
        public static explicit operator AccountRoleDtoGet(AccountRole accountRole)
        {
            return new AccountRoleDtoGet
            {
                Guid = accountRole.Guid,
                AccountGuid = accountRole.AccountGuid,
                RoleGuid = accountRole.RoleGuid
            };
        }
    }
}