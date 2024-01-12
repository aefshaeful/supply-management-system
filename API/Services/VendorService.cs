using API.Contracts;
using API.DataTransferObjects.TenderProjects;

namespace API.Services
{
    public class VendorService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
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
            var vendorCreated = _vendorRepository.Create(vendorDtoCreate);
            if (vendorCreated is null)
            {
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