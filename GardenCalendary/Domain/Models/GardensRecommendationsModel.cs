namespace Domain.Models;
    public class GardensRecommendationsModel
    {
        public int UserId { get; set; }
        public List<GardensModel> Gardens { get; set; } = new();
    }

    public class GardensModel
    {
        public int Id { get; set; }

        public string? CityName { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<PlantWithRecommendations> PlantsWithRecommendations { get; set; } = new();
    }

    public class PlantWithRecommendations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RPlantId { get; set; }
        public RecommendationModel Recommendation { get; set; } = new();
    }
