using API.Models;

namespace API.Contracts
{
    public interface IAccountRoleRepository : IBaseRepository<AccountRole>
    {
        IEnumerable<AccountRole> GetAccountRoleByAccountGuid(Guid guid);
    }
};