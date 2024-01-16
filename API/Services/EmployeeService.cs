using API.Contracts;
using API.DataTransferObjects.Employees;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;

namespace API.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountForEmployeeRepository _accountForEmployeeRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IAccountForEmployeeRepository accountForEmployeeRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository)
        {
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
            var employeeCreated = _employeeRepository.Create(employeeDtoCreate);
            if (employeeCreated is null) return null!;
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
            var employee = _employeeRepository.GetByGuid(guid);

            if (employee is null)
            {
                return -1;
            }

            var employeeDeleted = _employeeRepository.Delete(employee);
            return !employeeDeleted ? 0 : 1;
        }
    }
}
