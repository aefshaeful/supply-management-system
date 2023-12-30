using API.Models;
using API.Utilities.Handlers;
using System.Security.Principal;

namespace API.DataTransferObjects
{
    public class AccountForEmployeeDtoUpdate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;

        // implicit operator
        public static implicit operator AccountForEmployee(AccountForEmployeeDtoUpdate accountDtoUpdate)
        {
            return new()
            {
                Guid = accountDtoUpdate.Guid,
                Password = HashingHandler.HashPassword(accountDtoUpdate.Password),
                ModifiedDate = DateTime.UtcNow
            };
        }

        public static explicit operator AccountForEmployeeDtoUpdate(AccountForEmployee account)
        {
            return new()
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }
}