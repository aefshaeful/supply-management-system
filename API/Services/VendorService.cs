using API.Contracts;
using API.DataTransferObjects.TenderProjects;
using API.Models;

namespace API.Services
{
    public class VendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IAccountForVendorRepository _accountForVendorRepository;

        public VendorService(IVendorRepository vendorRepository, IAccountForVendorRepository accountForVendorRepository)
        {
            _vendorRepository = vendorRepository;
            _accountForVendorRepository = accountForVendorRepository;
        }

        public IEnumerable<VendorDtoGet> Get()
        {
            var vendors = _vendorRepository.GetAll().ToList();
            if (!vendors.Any())
            {
                return Enumerable.Empty<VendorDtoGet>();
            }

            List<VendorDtoGet> vendorDtoGets = new();

            foreach (var vendor in vendors)
            {
                vendorDtoGets.Add((VendorDtoGet)vendor);
            }

            return vendorDtoGets;
        }

        public VendorDtoGet? Get(Guid guid)
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor is null)
            {
                return null!;
            }

            return (VendorDtoGet)vendor;
        }

        public VendorDtoCreate? Create(VendorDtoCreate vendorDtoCreate)
        {
            Vendor vendor = vendorDtoCreate;
            var vendorCreated = _vendorRepository.Create(vendor);

            var randomPassword = "vendor123";

            var account = new AccountForVendor
            {
                Guid = vendor.Guid,
                Password = randomPassword,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            var accountForVendorCreated = _accountForVendorRepository.Create(account);
            

            if (vendorCreated is null)
            {
                _accountForVendorRepository.Delete(accountForVendorCreated);
                return null!;
            }

            return (VendorDtoCreate)vendorCreated;
        }

        public int Update(VendorDtoUpdate vendorDtoUpdate)
        {
            var vendor = _vendorRepository.GetByGuid(vendorDtoUpdate.Guid);
            if (vendor is null)
            {
                return -1;
            }

            var vendorUpdated = _vendorRepository.Update(vendorDtoUpdate);
            return !vendorUpdated ? 0 : 1;
        }

        public int Delete(Guid guid)
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor is null)
            {
                return -1;
            }

            var vendorDeleted = _vendorRepository.Delete(vendor);
            return !vendorDeleted ? 0 : 1;
        }
    }
}