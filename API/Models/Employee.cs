namespace API.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

    }
}
