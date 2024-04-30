using PKHeX.Core;

namespace CFPkHex.Backend.Repository
{
    public class InventoryBuilderRepository
    {
        public IInventoryRepository GetInventoryRepository(object obj)
        {
            if (obj is SAV4 save)
            {
                return new Gen4Repository(save);
            }

            throw new NotImplementedException("Generación no implementada");
        }
    }
}
