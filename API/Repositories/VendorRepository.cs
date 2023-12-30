using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(SupplyManegementDbContext context) : base(context){}

        public Vendor? GetVendorByGuid(Guid guid)
        {
             return Context.Set<Vendor>().FirstOrDefault(v => v.Guid == guid);
        }
    }
};