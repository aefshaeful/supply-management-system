using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SupplyManegementDbContext context) : base(context){}

        public Employee? GetEmployeeByEmail(string email)
        {
             return Context.Set<Employee>().FirstOrDefault(e => e.Email == email);
        }
    }
};