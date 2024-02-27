using GardeningTipsService.Interfaces;
using GardeningTipsService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GardeningTipsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;
     
        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }


        [HttpGet("GardenId")]
        public async Task<ActionResult<List<RecommendationModel>>> GetAllRecommendations(int gardenId)
        {
            return Ok(await _recommendationService.GetAllRecommendations(gardenId));
        }

        [HttpGet("GetRecommendationByPlantId/GardenId")]
        public async Task<ActionResult<RecommendationModel>> GetAllRecommendations(int gardenId, int plantId)
        {
            return Ok(await _recommendationService.GetRecommendationByPlantId(gardenId, plantId));
        }
    }
}