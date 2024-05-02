
using CFPkHex.Backend.Models;
using CFPkHex.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using PKHeX.Core;


[ApiController]
[Route("/api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly BuilderRepository _builderRepository;
    public InventoryController(
        BuilderRepository boxBuilderRepository
    )
    {
        _builderRepository = boxBuilderRepository;
    }

    [HttpPost("add-max-rare-candies")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> AddMaxRareCandies([FromForm] AddMaxCandiesRequest request)
    {
        using var ms = new MemoryStream();
        var savePokemonFile = request.SavePokemonFile;
        var ext = Path.GetExtension(savePokemonFile.FileName);
        await savePokemonFile.CopyToAsync(ms);
        var obj = FileUtil.GetSupportedFile(ms.ToArray(), ext, null);

        IInventoryRepository boxRepository = _builderRepository.GetRepository(obj!);
        var newSaveFile = boxRepository.AddMaxCandies();

        return File(newSaveFile.Data, "application/octet-stream", savePokemonFile.FileName);
    }
}