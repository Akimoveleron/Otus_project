using GardeningTipsService.Entities;
using GardeningTipsService.Interfaces;
using GardeningTipsService.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GardeningTipsService.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly GardenTipsContext _context;
        private readonly IWeatherForRecommendationService _weatherForRecommendationService;
        public int GardenId = 0;

        public RecommendationService(GardenTipsContext context,
            IWeatherForRecommendationService weatherForRecommendationService)
        {
            _context = context;
            _weatherForRecommendationService = weatherForRecommendationService;
        }

        public async Task<List<RecommendationModel>> GetAllRecommendations(int curGardenId)
        {
            GardenId = curGardenId;
            //List<string> resultRecommendation = new List<string>();
            List<RecommendationModel> recommendations = new List<RecommendationModel>();

            var gardenAndPlant = _context.Set<PlantInGarden>().Join(_context.Set<RPlant>(),
                  k => k.RPlantId,
                  i => i.Id,
                  (k, i) => new
                  {
                      PlantInGardenId = k.Id,
                      PlantId = i.Id,
                      i.Id,
                      i.Name,
                      Planting = k.DatePlanting,
                      Watering = k.DateWatering,
                      Hoeing = k.DateHoeing,
                      Loosening = k.DateLoosening,
                      Weeding = k.DateWeeding,
                      Harvesting = k.DateHarvesting,
                      NumberMonchsPlanting = i.NumberMonthsForPlanting,
                      MinTemperaaturaPlanting = i.MinTemperaturaForPlanting,
                      FirstWateringAfterPlating = i.FirstWateringAfterPlanting,
                      i.WateringPeriod,
                      HoeingAfterPlanring = i.HoeingAfterPlanting,
                      looseningPeriod = i.LooseningPeriod,
                      i.WeedingPeriod,
                      i.HarvestingAfterPlanting,

                  }).ToList();

            int? minTempForFiveDays = await _weatherForRecommendationService.MinTemperaturaForFiveDays(GardenId);

            foreach (var item in gardenAndPlant)
            {
                recommendations.Add(new RecommendationModel
                {
                    PlantId = item.PlantId,
                    PlantInGardenId = item.PlantInGardenId,
                    PlantName = item.Name,
                    Planting = GetRecommendationsForPlanting(item.Name, item.Planting, item.NumberMonchsPlanting,
                    item.MinTemperaaturaPlanting, minTempForFiveDays),
                    Watering = GetRecommendationsForWatering(item.Name, item.Planting, item.Watering,
                    item.FirstWateringAfterPlating, item.WateringPeriod),
                    Hoeing = GetRecommendationsForHoeing(item.Name, item.Planting, item.HoeingAfterPlanring),
                    Loosing = GetRecommendationsloosing(item.Name, item.Planting, item.Loosening, item.looseningPeriod),
                    Weeding = GetRecommendationsWeeding(item.Name, item.Planting, item.Weeding, item.WeedingPeriod)
                });
            };

            return recommendations;
        }

        public async Task<RecommendationModel> GetRecommendationByPlantId(int curGardenId, int curPlantId)
        {
            GardenId = curGardenId;
            //List<string> resultRecommendation = new List<string>();
            var recommendation = new RecommendationModel();

            var gardenAndPlant = await _context.Set<PlantInGarden>().Join(_context.Set<RPlant>(),
                  k => k.RPlantId,
                  i => i.Id,
                  (k, i) => new
                  {
                      i.Id,
                      i.Name,
                      Planting = k.DatePlanting,
                      Watering = k.DateWatering,
                      Hoeing = k.DateHoeing,
                      Loosening = k.DateLoosening,
                      Weeding = k.DateWeeding,
                      Harvesting = k.DateHarvesting,
                      NumberMonchsPlanting = i.NumberMonthsForPlanting,
                      MinTemperaaturaPlanting = i.MinTemperaturaForPlanting,
                      FirstWateringAfterPlating = i.FirstWateringAfterPlanting,
                      i.WateringPeriod,
                      HoeingAfterPlanring = i.HoeingAfterPlanting,
                      looseningPeriod = i.LooseningPeriod,
                      i.WeedingPeriod,
                      i.HarvestingAfterPlanting,

                  }).FirstOrDefaultAsync(k => k.Id == curPlantId);

            int? minTempForFiveDays = await _weatherForRecommendationService.MinTemperaturaForFiveDays(GardenId);

            recommendation = new RecommendationModel
            {
                PlantName = gardenAndPlant.Name,
                Planting = GetRecommendationsForPlanting(gardenAndPlant.Name, gardenAndPlant.Planting, gardenAndPlant.NumberMonchsPlanting,
                gardenAndPlant.MinTemperaaturaPlanting, minTempForFiveDays),
                Watering = GetRecommendationsForWatering(gardenAndPlant.Name, gardenAndPlant.Planting, gardenAndPlant.Watering,
                gardenAndPlant.FirstWateringAfterPlating, gardenAndPlant.WateringPeriod),
                Hoeing = GetRecommendationsForHoeing(gardenAndPlant.Name, gardenAndPlant.Planting, gardenAndPlant.HoeingAfterPlanring),
                Loosing = GetRecommendationsloosing(gardenAndPlant.Name, gardenAndPlant.Planting, gardenAndPlant.Loosening, gardenAndPlant.looseningPeriod),
                Weeding = GetRecommendationsWeeding(gardenAndPlant.Name, gardenAndPlant.Planting, gardenAndPlant.Weeding, gardenAndPlant.WeedingPeriod)
            };

            return recommendation;
        }

        public string GetRecommendationsForPlanting(string name, DateTime? planting, int[] monthPlating, int? minTemperaaturaPlanting, int? minTempForFiveDays)
        {
            if (planting is null)
            {
                if (monthPlating.Contains(int.Parse(DateTime.Now.Month.ToString())) && minTemperaaturaPlanting < minTempForFiveDays)
                {
                    return $"Рекомендуется посадить {name} в ближайшие дни";
                }
                else if (minTemperaaturaPlanting > minTempForFiveDays)
                {
                    return $"Сажать {name} не следует, стоит подождать когда станет потеплее";
                }
                else
                {
                    return $"Сажать {name} рано, стоит подождать до {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthPlating.Min())}";
                }
            }
            else
            {
                return $"Отлично, {name} посажен";
            }

        }

        public string GetRecommendationsForWatering(string name, DateTime? planting, DateTime? watering, int? firstWateringAfterPlating, int? wateringPeriod)
        {
            if (planting is null) return string.Empty;
            int daysAfterPlanting = DateTime.Now.Subtract((DateTime)planting).Days;
            int daysAfterLastWatering = DateTime.Now.Subtract((DateTime)watering).Days;
            if (daysAfterPlanting < firstWateringAfterPlating)
            {
                return $"Рекомендуется осуществить полив {name} через {firstWateringAfterPlating - daysAfterPlanting} дней ";
            }
            else if (daysAfterLastWatering < wateringPeriod)
            {
                return $"Рекомендуется осуществить полив {name} через {wateringPeriod - daysAfterLastWatering} дней";
            }
            else
            {
                return $"Необходимо немедленно полить {name}";
            }

        }

        public string GetRecommendationsForHoeing(string name, DateTime? planting, int[]? hoeingAfterPlanting)
        {
            if (planting is null) return string.Empty;
            int daysAfterPlanting = DateTime.Now.Subtract((DateTime)planting).Days;

            if (hoeingAfterPlanting is null || daysAfterPlanting > hoeingAfterPlanting.Max()) return $"Окучивание {name} не требуется";
            int daysBeforeHoeining = hoeingAfterPlanting[0] - daysAfterPlanting;

            for (int i = hoeingAfterPlanting.Length - 1; i >= 0; i--)
            {
                if (daysAfterPlanting > hoeingAfterPlanting[i])
                {
                    daysBeforeHoeining = hoeingAfterPlanting[i + 1] - daysAfterPlanting;
                }
            }

            return $"Необходимо окучить {name} через {daysBeforeHoeining} дней";
        }


        public string GetRecommendationsloosing(string name, DateTime? planting, DateTime? loosening, int? looseningPeriod)
        {
            if (planting is null) return string.Empty;
            int daysAfterLoosening = DateTime.Now.Subtract((DateTime)loosening).Days;
            if (daysAfterLoosening < looseningPeriod)
            {
                return $"Рекомендуется рыхление через {looseningPeriod - daysAfterLoosening} дней";
            }
            else
            {
                return $"Требуется срочное рыхление!";
            }

        }

        public string GetRecommendationsWeeding(string name, DateTime? planting, DateTime? weeding, int? weedingPeriod)
        {
            if (planting is null) return string.Empty;
            int daysAfterWeeding = DateTime.Now.Subtract((DateTime)weeding).Days;
            if (daysAfterWeeding < weedingPeriod)
            {
                return $"Рекомендуется прополка через {weedingPeriod - daysAfterWeeding} дней";
            }
            else
            {
                return $"Требуется срочная прополка!";
            }
        }


        public string GetRecommendationsHarvesting(string name, DateTime? planting, int? harvestingAfterPlanting)
        {
            if (planting is null) return string.Empty;
            int daysAfterPlanting = DateTime.Now.Subtract((DateTime)planting).Days;
            if (daysAfterPlanting < harvestingAfterPlanting)
            {
                return $"Рекомендуется уборка урожая {name} через {harvestingAfterPlanting - daysAfterPlanting} дней";
            }
            else
            {
                return $"Требуется собрать урожай {name}";
            }
        }
    }
}
