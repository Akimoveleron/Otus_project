using GardeningTipsService.Entities;
using GardeningTipsService.Interfaces;


namespace GardeningTipsService.Services
{
    public class GardeningSimulationService : IGardeningSimulationService
    {
        int GardenId;
        private readonly GardenTipsContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWeatherForRecommendationService _weatherForRecommendationService;

        public GardeningSimulationService(GardenTipsContext context,
            IConfiguration configuration, IWeatherForRecommendationService weatherForRecommendationService)
        {
            _context = context;
            _configuration = configuration;
            _weatherForRecommendationService = weatherForRecommendationService;
        }

        public async Task UserSimulation(int gardenId)
        {
            GardenId = gardenId;

            var plantInGarden = _context.Set<PlantInGarden>().ToList();

            foreach (var item in plantInGarden)
            {
                if (item.DatePlanting is null) continue;

                var random = new Random();
                DateTime dataPlanting = (DateTime)item.DatePlanting;

                DateTime lastDayOfPrecipitation = (DateTime)await _weatherForRecommendationService.LastDayOfPrecipitation(GardenId);
                int daysAfterPrecipitation = (lastDayOfPrecipitation - dataPlanting).Days;
                int daysAfterPlanting = (DateTime.Now - dataPlanting).Days;

                item.DateWatering = dataPlanting.AddDays(Math.Max(random.Next(daysAfterPlanting), daysAfterPrecipitation));
                item.DateHoeing = dataPlanting.AddDays(random.Next(daysAfterPlanting));
                item.DateLoosening = dataPlanting.AddDays(random.Next(daysAfterPlanting));
                item.DateWeeding = dataPlanting.AddDays(random.Next(daysAfterPlanting));

                await _context.SaveChangesAsync();
            }
        }
    }
}
