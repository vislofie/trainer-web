namespace api.Models;

public class SetItem
{
    public int Id { get; set; }
    public float Weight { get; set; }
    public int Repetitions { get; set; }
    public int ItemNumber { get; set; }

    // foreign key
    public int SetId { get; set; }
    public Set Set { get; set; }
}
