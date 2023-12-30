using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class TenderProjectRepository : BaseRepository<TenderProject>, ITenderProjectRepository
    {
        public TenderProjectRepository(SupplyManegementDbContext context) : base(context){}
    }
};