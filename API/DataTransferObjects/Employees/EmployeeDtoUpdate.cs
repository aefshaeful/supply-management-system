using API.Models;

namespace API.DataTransferObjects.Employees
{
    public class EmployeeDtoUpdate
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        // implicit operator
        public static implicit operator Employee(EmployeeDtoUpdate dto)
        {
            return new Employee
            {
                Guid = dto.Guid,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                ModifiedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator EmployeeDtoUpdate(Employee employee)
        {
            return new EmployeeDtoUpdate
            {
                Guid = employee.Guid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };
        }
    }
}