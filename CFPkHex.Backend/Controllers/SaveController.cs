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
            await saveGame.CopyToAsync(ms);

            var repository = _builderRepository.GetRepository(ms.ToArray(), saveGame.FileName);
            var saveInfo = repository.GetSaveInfo();

            return Ok(saveInfo);
        }
    }
}
