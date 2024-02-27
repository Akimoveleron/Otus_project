namespace Domain.Models.Data;

public class PlantModel
{
    public int Id { get; set; }
    public int? PlantInGardenId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Recommendation { get; set; } = string.Empty;
}