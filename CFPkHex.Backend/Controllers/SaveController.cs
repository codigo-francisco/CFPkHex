using CFPkHex.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PKHeX.Core;

namespace CFPkHex.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SaveController : ControllerBase
    {
        private readonly BuilderRepository _builderRepository;
        public SaveController(
            BuilderRepository builderRepository
        )
        {
            _builderRepository = builderRepository;
        }

        [HttpPost("save-info")]
        public async Task<IActionResult> GetSaveInfo(IFormFile saveGame)
        {
            using var ms = new MemoryStream();
            var ext = Path.GetExtension(saveGame.FileName);
            await saveGame.CopyToAsync(ms);
            var obj = FileUtil.GetSupportedFile(ms.ToArray(), ext, null);

            if (obj != null)
            {
                var repository = _builderRepository.GetRepository(obj);
                var saveInfo = repository.GetSaveInfo();

                return Ok(saveInfo);
            }
            else
            {
                throw new Exception("Archivo no soportado");
            }
        }
    }
}
