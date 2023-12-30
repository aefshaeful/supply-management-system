using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class AccountForEmployeeRepository : BaseRepository<AccountForEmployee>, IAccountForEmployeeRepository
    {
        public AccountForEmployeeRepository(SupplyManegementDbContext context) : base(context){}
    }
};