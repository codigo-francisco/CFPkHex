using PKHeX.Core;

namespace CFPkHex.Backend.Repository
{
    public class Gen4Repository : IInventoryRepository
    {
        private readonly SAV4 _save;
        public Gen4Repository(SAV4 save) 
        {
            _save = save;
        }
        public SaveFile AddMaxCandies()
        {
            var original = _save.Clone();

            var inventories = _save.Inventory.ToList();

            foreach (InventoryPouch4 inventoryPouch in inventories)
            {
                if (inventoryPouch.Type == InventoryType.Medicine)
                {
                    var maxCountItem = inventoryPouch.MaxCount;
                    var newIndex = inventoryPouch.Count;
                    //El item 50 es el rare candy
                    var newRareCandies = inventoryPouch.GetEmpty(50, maxCountItem);
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
