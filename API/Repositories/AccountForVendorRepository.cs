using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class AccountForVendorRepository : BaseRepository<AccountForVendor>, IAccountForVendorRepository
    {
        public AccountForVendorRepository(SupplyManegementDbContext context) : base(context) { }

    }
}