using api.Repositories.Interfaces;

namespace api.Repositories.Implementations;

public class FileHandlerLocal : IFileHandlerRepository
{
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

        using (FileStream writeStream = File.OpenWrite(path))
        {
            await stream.CopyToAsync(writeStream);
            return filePath;
        }
    }
}
