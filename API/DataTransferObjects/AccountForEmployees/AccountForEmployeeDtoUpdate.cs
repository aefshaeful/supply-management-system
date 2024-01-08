using API.Models;
using API.Utilities.Handlers;
using System.Security.Principal;

namespace API.DataTransferObjects.AccountForEmployees
{
    public class AccountForEmployeeDtoUpdate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;

        // implicit operator
        public static implicit operator AccountForEmployee(AccountForEmployeeDtoUpdate dto)
        {
            return new()
            {
                Guid = dto.Guid,
                Password = HashingHandler.HashPassword(dto.Password),
                ModifiedDate = DateTime.UtcNow
            };
        }

        // explicit operator
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