using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/arquivos")]
public class ArquivosController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

    public ArquivosController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
    }

    [HttpGet("{id}")]
    public ActionResult ObterArquivo(string id)
    {
        var caminhoArquivo = "conta.pdf";

        if (!System.IO.File.Exists(caminhoArquivo))
        {
            return NotFound();
        }

        if (!_fileExtensionContentTypeProvider.TryGetContentType(caminhoArquivo, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        var bytes = System.IO.File.ReadAllBytes(caminhoArquivo);

        return File(bytes, contentType, Path.GetFileName(caminhoArquivo));
    }
}