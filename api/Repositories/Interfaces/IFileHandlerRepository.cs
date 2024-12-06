namespace api.Repositories.Interfaces;

public interface IFileHandlerRepository
{
    public Task<MemoryStream?> GetFileAsync(string filePath);
    public Task<string> UploadFileAsync(string filePath, MemoryStream memoryStream);
    public Task CleanUnusedFilesAsync();
}
