namespace Domain.Models;

public class CreateGardenModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }
}