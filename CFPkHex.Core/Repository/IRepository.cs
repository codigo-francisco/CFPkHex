using CFPkHex.Core.Repository;

namespace CFPkHex.Backend.Repository
{
    public interface IRepository : IInventoryRepository, ISaveInfo, IBoxRepository
    {
    }
}
