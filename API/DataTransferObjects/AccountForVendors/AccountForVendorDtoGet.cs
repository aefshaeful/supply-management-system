using API.Models;

namespace API.DataTransferObjects.AccountForVendors
{
    public class AccountForVendorDtoGet
    {
        public Guid Guid { set; get; }
        public string Password { set; get; } = default!;

        // implicit operator
        public static implicit operator AccountForVendor(AccountForVendorDtoGet dto)
        {
            return new AccountForVendor
            {
                Guid = dto.Guid,
                Password = dto.Password,
            };
        }

        // explicit operator
        public static explicit operator AccountForVendorDtoGet(AccountForVendor account)
        {
            return new AccountForVendorDtoGet
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }
}