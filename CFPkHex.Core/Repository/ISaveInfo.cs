using CFPkHex.Backend.Models.General;
using PKHeX.Core;

namespace CFPkHex.Backend.Repository
{
    public interface ISaveInfo
    {
        string FileName { get; set; }
        SaveFile SaveFile { get; }
        SaveInfo GetSaveInfo();
    }
}
