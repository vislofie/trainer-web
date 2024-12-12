using api.Infrastructure;
using api.DTOs.FileController;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/file")]
public class FileController : ControllerBase
{
    private readonly IFileHandlerRepository _fileHandlerRepository;
    private readonly ApplicationDbContext _context;
    public FileController(IFileHandlerRepository fileHandlerRepository, ApplicationDbContext context)
    {
        _fileHandlerRepository = fileHandlerRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]int fileId) 
    {
        Models.FileInfo? fileInfo = await _context.FileInfos.FirstOrDefaultAsync(fi => fi.Id == fileId);
        if (fileInfo == null)
            return BadRequest("No file with this id found");

        var fileStream = await _fileHandlerRepository.GetFileAsync(fileInfo.Path);
        if (fileStream == null)
            return BadRequest("No such file");
        
        return new FileStreamResult(fileStream, "application/octet-stream")
        {
            FileDownloadName = fileInfo.Name
        };
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Upload([FromForm]UploadFileDto uploadDto)
    {
        if (uploadDto.File.Length / 1000 / 1000 > 10)
            return BadRequest("File too big! Max amount is 10 MB");

        MemoryStream fileStream = new MemoryStream();
        await uploadDto.File.CopyToAsync(fileStream);

        await _context.FileInfos.AddAsync(new Models.FileInfo 
        {
            Name = uploadDto.File.FileName,
            Path = uploadDto.Path,
            Size = uploadDto.File.Length,
            Type = uploadDto.Type
        });

        string filePath = await _fileHandlerRepository.UploadFileAsync(uploadDto.Path, fileStream);
        if (filePath == "")
            return BadRequest("Error with uploading");

        return Ok();
    }
}
