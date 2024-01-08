using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Employee? GetEmployeeByEmail(string email);
    }
};