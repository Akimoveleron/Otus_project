namespace GardeningTipsService.Models
{
    public class RecommendationModel
    {
        public int PlantId { get; set; }
        public int PlantInGardenId { get; set; }
        public string PlantName { get; set; } = string.Empty;
        public string Planting { get; set; } = string.Empty;
        public string? Watering { get; set; }
        public string? Hoeing { get; set; }
        public string? Loosing { get; set; }
        public string? Weeding { get; set; }
    }
}
