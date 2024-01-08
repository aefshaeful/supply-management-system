using API.Models;
using API.Utilities.Handlers;

namespace API.DataTransferObjects.AccountForVendors
{
    public class AccountForVendorDtoCreate
    {
        public Guid Guid { get; set; }
        public string Password { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // implicit operator
        public static implicit operator AccountForVendor(AccountForVendorDtoCreate dto)
        {
            return new AccountForVendorDtoCreate
            {
                Guid = dto.Guid,
                Password = HashingHandler.HashPassword(dto.Password),
                CreatedDate = DateTime.UtcNow
            };
        }


        // explicit operator
        public static explicit operator AccountForVendorDtoCreate(AccountForVendor account)
        {
            return new AccountForVendorDtoCreate
            {
                Guid = account.Guid,
                Password = account.Password,
            };
        }
    }
}