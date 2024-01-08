using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(SupplyManegementDbContext context) : base(context){}

        public Vendor? GetVendorByEmail(string email)
        {
             return Context.Set<Vendor>().FirstOrDefault(v => v.Email == email);
        }
    }
};