namespace API.DataTransferObjects.AccountForVendors
{
    public class AccountRegisterVendorDto
    {
        public string CompanyName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string PhotoProduct { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}