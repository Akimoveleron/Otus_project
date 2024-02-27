namespace Domain.Models.Data;

public class GardenModel
{
    public int tempId { get; set; }
    public int? Id { get; set; }
    public int? UserGardenId { get; set; }
    public string Name { get; set; } 
    public RegionModel Region { get; set; }
    public List<PlantModel> Plants { get; set; }
}