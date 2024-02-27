using GardeningTipsService.Entities;
using GardeningTipsService.Interfaces;
using GardeningTipsService.Models;
using Newtonsoft.Json;

namespace GardeningTipsService.Services
{
    public class WeatherForRecommendationService : IWeatherForRecommendationService
    {
        private readonly IConfiguration _configuration;
        private readonly GardenTipsContext _context;

        public WeatherForRecommendationService(GardenTipsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public int? GetAccuweatherId(int gardenId)
        {
            int? accuweatherId = _context.Set<RReestrObject>().
                Where(item => item.Id == _context.Set<Garden>().First(item => item.Id == gardenId).ObjectId).First().
                AccuweatherId;
            return accuweatherId;
        }

        public async Task<int?> MinTemperaturaForFiveDays(int gardenId)
        {

            int? accuweatherId = GetAccuweatherId(gardenId);
            string url = $"{_configuration["AccuWeatherMSBaseAddres"]}/GetWeatherByLocationKey/{accuweatherId}?days=5";
            StringContent data = new($"{accuweatherId}");
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string responseText = await response.Content.ReadAsStringAsync();
            List<WeatherCalendarModel> weather = JsonConvert.DeserializeObject<List<WeatherCalendarModel>>(responseText);

            int? minTemperatiraForFiveDays = weather.Select(item => item.TemperaturaMin).Min();



            return minTemperatiraForFiveDays;
        }

        public async Task<DateTime?> LastDayOfPrecipitation(int gardenId)
        {
            int? accuweatherId = GetAccuweatherId(gardenId);
            string url = $"{_configuration["AccuWeatherMSBaseAddres"]}/PrecipitationLastDate/{accuweatherId}";
            StringContent data = new($"{accuweatherId}");
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            string responseText = await response.Content.ReadAsStringAsync();
            DateTime lastDayOfPrecipitation = JsonConvert.DeserializeObject<DateTime>(responseText);
            
            return lastDayOfPrecipitation;
        }
    }
}
