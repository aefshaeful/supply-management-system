using API.Models;

namespace API.DataTransferObjects.AccountForEmployees
{
    public class AccountForEmployeeDtoGet
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;

        // implicit operator
        public static implicit operator AccountForEmployee(AccountForEmployeeDtoGet dto)
        {
            return new AccountForEmployee
            {
                Guid = dto.Guid,
                Password = dto.Password,
            };
        }


        // explicit operator
        public static explicit operator AccountForEmployeeDtoGet(AccountForEmployee account)
        {
            return new AccountForEmployeeDtoGet
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }
}