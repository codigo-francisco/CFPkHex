using PKHeX.Core;

namespace CFPkHex.Backend.Repository
{
    public class BuilderRepository
    {
        public IRepository GetRepository(byte[] dataFile, string fileName)
        {
            var ext = Path.GetExtension(fileName);
            var obj = FileUtil.GetSupportedFile(dataFile, ext, null);

            if (obj is SAV3 save3)
            {
                return new Gen3Repository(save3)
                {
                    FileName = fileName
                };
            }
            else if (obj is SAV4 save4)
            {
                return new Gen4Repository(save4)
                { 
                    FileName = fileName
                };
            }

            throw new NotImplementedException("Generación no implementada");
        }
    }
}
