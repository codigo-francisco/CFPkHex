using PKHeX.Core;

namespace CFPkHex.Backend.Repository
{
    public class Gen3Repository : IInventoryRepository
    {
        private readonly SAV3 _save;
        public Gen3Repository(SAV3 save) 
        {
            _save = save;
        }
        public SaveFile AddMaxCandies()
        {
            var original = _save.Clone();

            var inventories = _save.Inventory.ToList();

            foreach (InventoryPouch3 inventoryPouch in inventories)
            {
                if (inventoryPouch.Type == InventoryType.PCItems)
                {
                    var maxCountItem = inventoryPouch.MaxCount;
                    var newIndex = inventoryPouch.Count;
                    //El item 68 es el rare candy
                    var newRareCandies = inventoryPouch.GetEmpty(68, maxCountItem);
                    inventoryPouch.Items[newIndex] = newRareCandies;

                    break;
                }
            }

            _save.Inventory = inventories;

            original.CopyChangesFrom(_save);

            return original;
        }
    }
}
