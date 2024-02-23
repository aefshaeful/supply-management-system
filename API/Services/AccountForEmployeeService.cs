using System.Linq.Expressions;
using System.Security.Claims;
using API.Contracts;
using API.Data;
using API.DataTransferObjects.AccountForEmployees;
using API.Models;
using API.Utilities.Handlers;
namespace API.Services
{
    public class AccountForEmployeeService
    {
        private readonly SupplyManegementDbContext _context;
        private readonly IAccountForEmployeeRepository _accountForEmployeeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenHandler _tokenHandler;


        public AccountForEmployeeService(SupplyManegementDbContext context, IAccountForEmployeeRepository accountForEmployeeRepository, IEmployeeRepository employeeRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, ITokenHandler tokenHandler)
        {
            _context = context;
            _accountForEmployeeRepository = accountForEmployeeRepository;
            _employeeRepository = employeeRepository;
            _accountRoleRepository = accountRoleRepository;
            _roleRepository = roleRepository;
            _tokenHandler = tokenHandler;
        }

        public IEnumerable<AccountForEmployeeDtoGet> Get()
        {
            var accountForEmployees = _accountForEmployeeRepository.GetAll().ToList();
            if (!accountForEmployees.Any())
            {
                return Enumerable.Empty<AccountForEmployeeDtoGet>();
            }

            List<AccountForEmployeeDtoGet> accountForEmployeeGets = new();

            foreach (var accountForEmployee in accountForEmployees)
            {
                accountForEmployeeGets.Add((AccountForEmployeeDtoGet)accountForEmployee);
            }

            return accountForEmployeeGets;
        }

        public AccountForEmployeeDtoGet? Get(Guid guid)
        {
            var accountForEmployee = _accountForEmployeeRepository.GetByGuid(guid);
            if (accountForEmployee is null)
            {
                return null!;
            }

            return (AccountForEmployeeDtoGet)accountForEmployee;
        }

        public AccountForEmployeeDtoCreate? Create(AccountForEmployeeDtoCreate accountForEmployeeDtoCreate)
        {
            var accountForEmployeeCreated = _accountForEmployeeRepository.Create(accountForEmployeeDtoCreate);
            if (accountForEmployeeCreated is null)
            {
                return null!;
            }

            return (AccountForEmployeeDtoCreate)accountForEmployeeCreated;
        }

        public int Update(AccountForEmployeeDtoUpdate accountForEmployeeDtoUpdate)
        {
            var accountForEmployee = _accountForEmployeeRepository.GetByGuid(accountForEmployeeDtoUpdate.Guid);
            if (accountForEmployee is null)
            {
                return -1;
            }

            var accountForEmployeeUpdated = _accountForEmployeeRepository.Update(accountForEmployeeDtoUpdate);
            return !accountForEmployeeUpdated ? 0 : 1;
        }

        public int Delete(Guid guid)
        {
            using var transactions = _context.Database.BeginTransaction();
            try
            {
                var employee = _employeeRepository.GetByGuid(guid);
                if (employee is null)
                {
                    return -1;
                }

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

        public string Login(AccountLoginEmployeeDto accountLoginEmployeeDto)
        {
            var employee = _employeeRepository.GetEmployeeByEmail(accountLoginEmployeeDto.Email);
            if (employee is null)
            {
                return "0";
            }

            var accountForEmployee = _accountForEmployeeRepository.GetByGuid(employee.Guid);
            if (accountForEmployee is null)
            {
                return "0";
            }

            if (!HashingHandler.ValidatePassword(accountLoginEmployeeDto.Password, accountForEmployee!.Password))
            {
                return "-1";
            }

            try
            {
                var claims = new List<Claim>
                {
                    new Claim("Guid", employee.Guid.ToString()),
                    new Claim("FullName", $"{employee.FirstName} {employee.LastName}"),
                    new Claim("Email", accountLoginEmployeeDto.Email),
                };

                var accountRoles = _accountRoleRepository.GetAccountRoleByAccountGuid(employee.Guid);
                var getRolesNameByAccountRole = from accountRole in accountRoles
                                                join role in _roleRepository.GetAll() on accountRole.RoleGuid equals role.Guid
                                                select role.Name;

                claims.AddRange(getRolesNameByAccountRole.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = _tokenHandler.GenerateToken(claims);
                return token;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "-2";
            }
        }

        public bool Register(AccountRegisterEmployeeDto accountRegisterEmployeeDto)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var employee = new Employee
                {
                    Guid = new Guid(),
                    FirstName = accountRegisterEmployeeDto.FirstName,
                    LastName = accountRegisterEmployeeDto.LastName,
                    Email = accountRegisterEmployeeDto.Email,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                _employeeRepository.Create(employee);

                var accountForEmployee = new AccountForEmployee
                {
                    Guid = employee.Guid,
                    Password = HashingHandler.HashPassword(accountRegisterEmployeeDto.Password),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                _accountForEmployeeRepository.Create(accountForEmployee);

                var roleEmployee = _roleRepository.GetByName("Admin");

                _accountRoleRepository.Create(new AccountRole
                {
                    AccountGuid = accountForEmployee.Guid,
                    RoleGuid = roleEmployee.Guid,
                });

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}