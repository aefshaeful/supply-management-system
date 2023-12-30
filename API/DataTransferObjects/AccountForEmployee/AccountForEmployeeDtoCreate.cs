using API.Models;
using API.Utilities.Handlers;

namespace API.DataTransferObjects
{
    public class AccountForEmployeeDtoCreate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;

        public static implicit operator AccountForEmployee(AccountForEmployeeDtoCreate accountDtoCreate)
        {
            return new AccountForEmployee
            {
                Guid = accountDtoCreate.Guid,
                Password = HashingHandler.HashPassword(accountDtoCreate.Password),
                CreatedDate = DateTime.UtcNow
            };
        }

        public static explicit operator AccountForEmployeeDtoCreate(AccountForEmployee account)
        {
            return new AccountForEmployeeDtoCreate
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }

}