using API.Contracts;
using API.Data;
using API.DataTransferObjects.Employees;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;

namespace API.Services
{
    public class EmployeeService
    {
        private readonly SupplyManegementDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountForEmployeeRepository _accountForEmployeeRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public EmployeeService(SupplyManegementDbContext context, IEmployeeRepository employeeRepository, IAccountForEmployeeRepository accountForEmployeeRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _accountForEmployeeRepository = accountForEmployeeRepository;
            _accountRoleRepository = accountRoleRepository;
            _roleRepository = roleRepository;
        }

        public IEnumerable<EmployeeDtoGet> Get()
        {
            var employees = _employeeRepository.GetAll().ToList();
            if (!employees.Any()) return Enumerable.Empty<EmployeeDtoGet>();
            List<EmployeeDtoGet> employeeDtoGets = new();

            foreach (var employee in employees)
            {
                employeeDtoGets.Add((EmployeeDtoGet)employee);
            }

            return employeeDtoGets;
        }

        public EmployeeDtoGet? Get(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if (employee is null) return null!;

            return (EmployeeDtoGet)employee;
        }

        public EmployeeDtoCreate? Create(EmployeeDtoCreate employeeDtoCreate)
        {
            Employee employee = employeeDtoCreate;
            var employeeCreated = _employeeRepository.Create(employee);

            var randomPassword = "employee123";

            var account = new AccountForEmployee
            {
                Guid = employee.Guid,
                Password = HashingHandler.HashPassword(randomPassword),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            var accountForEmployeeCreated = _accountForEmployeeRepository.Create(account);
            var roleEmployee = _roleRepository.GetByName("Admin");
            var accountRoleCreated = _accountRoleRepository.Create(new AccountRole
            {
                AccountGuid = account.Guid,
                RoleGuid = roleEmployee.Guid
            });
            if (employeeCreated is null)
            {
                _accountForEmployeeRepository.Delete(accountForEmployeeCreated);
                _accountRoleRepository.Delete(accountRoleCreated);
                return null!;
            }

            return (EmployeeDtoCreate)employeeCreated;
        }


        public int Update(EmployeeDtoUpdate employeeDtoUpdate)
        {
            var employee = _employeeRepository.GetByGuid(employeeDtoUpdate.Guid);
            if (employee is null) return -1;

            var employeeUpdated = _employeeRepository.Update(employeeDtoUpdate);
            return !employeeUpdated ? 0 : 1;
        }

        public int Delete(Guid guid)
        {
            using (var transactions = _context.Database.BeginTransaction())
            {
                try
                {
                    var employee = _employeeRepository.GetByGuid(guid);
                    if (employee is null) return -1;

                    var accountForEmployee = _accountForEmployeeRepository.GetByGuid(guid);
                    if (accountForEmployee is not null)
                    {
                        _accountForEmployeeRepository.Delete(accountForEmployee);
                    }
                    _employeeRepository.Delete(employee);
                    transactions.Commit();
                    return 1;
                }
                catch
                {
                    transactions.Rollback();
                    return 0;
                }
            }
        }
    }
}
