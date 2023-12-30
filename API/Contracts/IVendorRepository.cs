using API.Models;

namespace API.Contracts
{
    public interface IVendorRepository : IBaseRepository<Vendor>
    {
        Vendor? GetVendorByGuid(Guid guid);
    }
};