using System.Security.Claims;
using API.Contracts;
using API.Data;
using API.DataTransferObjects.AccountForVendors;
using API.Models;
using API.Utilities.Handlers;

namespace API.Services
{
    public class AccountForVendorService
    {
        private readonly SupplyManegementDbContext _context;
        private readonly IAccountForVendorRepository _accountForVendorRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly ITokenHandler _tokenHandler;

        public AccountForVendorService(SupplyManegementDbContext context,
        IAccountForVendorRepository accountForVendorRepository,
        IVendorRepository vendorRepository,
        ITokenHandler tokenHandler)
        {
            _context = context;
            _accountForVendorRepository = accountForVendorRepository;
            _vendorRepository = vendorRepository;
            _tokenHandler = tokenHandler;
        }

        public IEnumerable<AccountForVendorDtoGet> Get()
        {
            var accountForVendors = _accountForVendorRepository.GetAll().ToList();

            if (!accountForVendors.Any())
            {
                return Enumerable.Empty<AccountForVendorDtoGet>();
            }

            List<AccountForVendorDtoGet> accountForVendorGets = new();

            foreach (var accountForVendor in accountForVendors)
            {
                accountForVendorGets.Add((AccountForVendorDtoGet)accountForVendor);
            }

            return accountForVendorGets;
        }

        public AccountForVendorDtoGet? Get(Guid guid)
        {
            var accountForVendor = _accountForVendorRepository.GetByGuid(guid);

            if (accountForVendor is null)
            {
                return null!;
            }

            return (AccountForVendorDtoGet)accountForVendor;
        }

        public AccountForVendorDtoCreate? Create(AccountForVendorDtoCreate accountForVendorDtoCreate)
        {
            var accountForVendorCreated = _accountForVendorRepository.Create(accountForVendorDtoCreate);

            if (accountForVendorCreated is null)
            {
                return null!;
            }

            return (AccountForVendorDtoCreate)accountForVendorCreated;
        }

        public int Update(AccountForVendorDtoUpdate accountForVendorDtoUpdate)
        {
            var accountForVendor = _accountForVendorRepository.GetByGuid(accountForVendorDtoUpdate.Guid);

            if (accountForVendor is null)
            {
                return -1;
            }

            var accountForVendorUpdated = _accountForVendorRepository.Update(accountForVendorDtoUpdate);
            return !accountForVendorUpdated ? 0 : 1;
        }

        public int Delete(Guid guid)
        {
            var accountForVendor = _accountForVendorRepository.GetByGuid(guid);

            if (accountForVendor is null)
            {
                return -1;
            }

            var accountForEmployeeDeleted = _accountForVendorRepository.Delete(accountForVendor);
            return !accountForEmployeeDeleted ? 0 : 1;
        }

        public string Login(AccountLoginVendorDto accountLoginVendorDto)
        {
            var vendor = _vendorRepository.GetVendorByEmail(accountLoginVendorDto.Email);

            if (vendor is null)
            {
                return "0";
            }

            var accountForVendor = _accountForVendorRepository.GetByGuid(vendor.Guid);
            if (accountForVendor is null)
            {
                return "0";
            }

            if (!HashingHandler.ValidatePassword(accountLoginVendorDto.Password, accountForVendor!.Password))
            {
                return "-1";
            }

            try
            {
                var claims = new List<Claim>()
                {
                    new Claim("Guid", vendor.Guid.ToString()),
                    new Claim("CompanyName", vendor.CompanyName),
                    new Claim("PhotoProduct", vendor.PhotoProduct),
                    new Claim("Email", accountLoginVendorDto.Email),
                };

                var token = _tokenHandler.GenerateToken(claims);
                return token;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "-2";
            }
        }

        public bool Register(AccountRegisterVendorDto accountRegisterVendorDto)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var vendor = new Vendor
                {
                    Guid = new Guid(),
                    CompanyName = accountRegisterVendorDto.CompanyName,
                    Email = accountRegisterVendorDto.Email,
                    PhoneNumber = accountRegisterVendorDto.PhoneNumber,
                    PhotoProduct = accountRegisterVendorDto.PhotoProduct,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };
                _vendorRepository.Create(vendor);

                var accountForVendor = new AccountForVendor
                {
                    Guid = vendor.Guid,
                    Password = HashingHandler.HashPassword(accountRegisterVendorDto.Password),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };
                _accountForVendorRepository.Create(accountForVendor);


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