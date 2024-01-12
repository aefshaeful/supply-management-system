using API.Models;

namespace API.DataTransferObjects.Employees
{
    public class EmployeeDtoGet
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        // implicit operator
        public static implicit operator Employee(EmployeeDtoGet dto)
        {
            return new Employee
            {
                Guid = dto.Guid,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            };
        }

        // explicit operator
        public static explicit operator EmployeeDtoGet(Employee employee)
        {
            return new EmployeeDtoGet
            {
                Guid = employee.Guid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };
        }
    }
}