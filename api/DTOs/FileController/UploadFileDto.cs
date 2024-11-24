namespace api.DTOs.FileController;

public class UploadFileDto
{
    public IFormFile File { get; set; }
    public string Path { get; set; }
    public string Type { get; set; }
}
