namespace API.DataTransferObjects.AccountForEmployees
{
    public class AccountLoginEmployeeDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}