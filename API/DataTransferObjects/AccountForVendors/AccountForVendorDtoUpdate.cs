using API.Models;

namespace API.DataTransferObjects.AccountForVendors
{
    public class AcoountForVendorDtoUpdate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;    

        // implicit operator
        public static implicit operator AccountForVendor(AcoountForVendorDtoUpdate dto)
        {
            return new AccountForVendor
            {
                Guid = dto.Guid,
                Password = dto.Password,
                ModifiedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator AcoountForVendorDtoUpdate(AccountForVendor account)
        {
            return new AcoountForVendorDtoUpdate
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }
}