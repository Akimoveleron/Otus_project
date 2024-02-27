using GardeningTipsService.Models;

namespace GardeningTipsService.Interfaces
{
    public interface IRecommendationService
    {
        Task<List<RecommendationModel>> GetAllRecommendations(int curGardenId);
        Task<RecommendationModel> GetRecommendationByPlantId(int curGardenId, int curPlantId);
    }
}
