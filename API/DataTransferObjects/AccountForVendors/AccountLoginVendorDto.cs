namespace API.DataTransferObjects.AccountForVendors
{
    public class AccountLoginVendorDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}