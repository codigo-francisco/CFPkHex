using CFPkHex.Backend.Models.General;
using CFPkHex.Backend.Repository;
using CFPkHex.Core.Models.General;
using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFPkHex.Core.Repository
{
    public abstract class BaseRepository : IRepository
    {
        protected readonly SaveFile _saveFile;
        protected IList<Box> _boxes;
        public required string FileName { get; set; }

        public SaveFile SaveFile
        {
            get => _saveFile;
        }

        public IList<Box> Boxes => _boxes;

        public BaseRepository(SaveFile saveFile)
        {
            _saveFile = saveFile;

            var names = BoxUtil.GetBoxNames(_saveFile);
            int currentBox = -1;
            _boxes = names.Select(n => new Box
            {
                Name = n,
                AllPokemon = _saveFile.GetBoxData(++currentBox).Select(pkm => new Pokemon
                {
                    Name = pkm.Nickname,
                    Level = Convert.ToInt32(pkm.CurrentLevel)
                }).ToList()
            }).ToList();
        }

        public abstract SaveFile AddMaxCandies();
        public abstract SaveInfo GetSaveInfo();
    }
}
