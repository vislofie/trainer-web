using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/file")]
public class FileController : ControllerBase
{
    private readonly IFileHandlerRepository _fileHandlerRepository;
    public FileController(IFileHandlerRepository fileHandlerRepository)
    {
        _fileHandlerRepository = fileHandlerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]string path) 
    {
        var fileStream = await _fileHandlerRepository.GetFileAsync(path);
        if (fileStream == null)
            return BadRequest("No such file");
        
        return new FileStreamResult(fileStream, "application/octet-stream")
        {
            FileDownloadName = Path.GetFileName(path)
        };
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Upload(IFormFile file, [FromQuery]string path)
    {
        if (file.Length / 1000 / 1000 > 10)
            return BadRequest("File too big! Max amount is 10 MB");

        MemoryStream fileStream = new MemoryStream();
        await file.CopyToAsync(fileStream);

        string filePath = await _fileHandlerRepository.UploadFileAsync(path, fileStream);
        if (filePath == "")
            return BadRequest("Error with uploading");

        return Ok();
    }
}
