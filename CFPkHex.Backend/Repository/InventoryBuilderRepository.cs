using PKHeX.Core;

namespace CFPkHex.Backend.Repository
{
    public class InventoryBuilderRepository
    {
        public IInventoryRepository GetInventoryRepository(object obj)
        {
            if (obj is SAV3 save3)
            {
                return new Gen3Repository(save3);
            }
            else if (obj is SAV4 save4)
            {
                return new Gen4Repository(save4);
            }

            throw new NotImplementedException("Generación no implementada");
        }
    }
}
