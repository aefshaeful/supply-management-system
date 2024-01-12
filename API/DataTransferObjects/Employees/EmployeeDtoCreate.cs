using API.Models;

namespace API.DataTransferObjects.Employees
{
    public class EmployeeDtoCreate
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        // implicit operator
        public static implicit operator Employee(EmployeeDtoCreate dto)
        {
            return new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator EmployeeDtoCreate(Employee employee)
        {
            return new EmployeeDtoCreate
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };
        }
    }
}