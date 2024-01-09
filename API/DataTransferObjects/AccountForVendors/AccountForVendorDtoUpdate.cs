using API.Models;

namespace API.DataTransferObjects.AccountForVendors
{
    public class AccountForVendorDtoUpdate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;

        // implicit operator
        public static implicit operator AccountForVendor(AccountForVendorDtoUpdate dto)
        {
            return new AccountForVendor
            {
                Guid = dto.Guid,
                Password = dto.Password,
                ModifiedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator AccountForVendorDtoUpdate(AccountForVendor account)
        {
            return new AccountForVendorDtoUpdate
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }
}