using CFPkHex.Backend.Models.General;
using CFPkHex.Backend.Repository;
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
        public required string FileName { get; set; }

        public SaveFile SaveFile
        {
            get => _saveFile;
        }

        public BaseRepository(SaveFile saveFile)
        {
            _saveFile = saveFile;
        }

        public abstract SaveFile AddMaxCandies();
        public abstract SaveInfo GetSaveInfo();
    }
}
