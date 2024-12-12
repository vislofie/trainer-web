using api.Infrastructure;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class FileHandlerLocal : IFileHandlerRepository
{
    private ApplicationDbContext _context;
    public FileHandlerLocal(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CleanUnusedFilesAsync()
    {
        var unusedFiles = await _context.FileInfos
            .Where(fi => !_context.Exercises.Any(e => e.PictureId == fi.Id || e.VideoId == fi.Id))
            .ToListAsync();
        
        if (unusedFiles.Any())
        {
            foreach (var file in unusedFiles)
            {
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Upload", file.Path));
            }
            _context.FileInfos.RemoveRange(unusedFiles);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<MemoryStream?> GetFileAsync(string filePath)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Upload", filePath);
        if (!File.Exists(path))
            return null;

        using (FileStream fileStream = File.OpenRead(path))
        {
            MemoryStream memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
    }

    public async Task<string> UploadFileAsync(string filePath, MemoryStream stream)
    {
        stream.Position = 0;

        string path = Path.Combine(Directory.GetCurrentDirectory(), "Upload", filePath);
        if (File.Exists(path))
            return "";

        Directory.CreateDirectory(Path.GetDirectoryName(path));

        using (FileStream writeStream = File.OpenWrite(path))
        {
            await stream.CopyToAsync(writeStream);
            return filePath;
        }
    }
}
