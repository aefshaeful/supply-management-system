using API.Models;

namespace API.Contracts
{
    public interface IVendorRepository : IBaseRepository<Vendor>
    {
        Vendor? GetVendorByEmail(string email);
    }
};