using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("FileInfo")]
public class FileInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long Size { get; set; }
    public string Type { get; set; } = string.Empty;
}
