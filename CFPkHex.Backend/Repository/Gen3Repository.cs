using CFPkHex.Backend.Models.General;
using PKHeX.Core;
using static System.Net.Mime.MediaTypeNames;

namespace CFPkHex.Backend.Repository
{
    public class Gen3Repository : IRepository
    {
        private readonly SAV3 _save;
        public Gen3Repository(SAV3 save) 
        {
            _save = save;
        }
        public SaveFile AddMaxCandies()
        {
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

            //Se ocupa ejecutar el write para que quede reflejado en el bloque Data
            _save.Write();

            return _save;
        }

        public SaveInfo GetSaveInfo()
        {
            throw new NotImplementedException();
        }
    }
}
