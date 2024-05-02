
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
        await savePokemonFile.CopyToAsync(ms);

        IInventoryRepository boxRepository = _builderRepository.GetRepository(ms.ToArray(), request.SavePokemonFile.FileName);
        var newSaveFile = boxRepository.AddMaxCandies();

        return File(newSaveFile.Data, "application/octet-stream", savePokemonFile.FileName);
    }
}