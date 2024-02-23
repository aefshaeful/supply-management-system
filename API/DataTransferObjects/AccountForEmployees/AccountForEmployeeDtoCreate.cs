using API.Models;
using API.Utilities.Handlers;

namespace API.DataTransferObjects.AccountForEmployees
{
    public class AccountForEmployeeDtoCreate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;

        // implicit operator
        public static implicit operator AccountForEmployee(AccountForEmployeeDtoCreate dto)
        {
            return new AccountForEmployee
            {
                Guid = dto.Guid,
                Password = HashingHandler.HashPassword(dto.Password),
                CreatedDate = DateTime.UtcNow
            };
        }


        // explicit operator
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