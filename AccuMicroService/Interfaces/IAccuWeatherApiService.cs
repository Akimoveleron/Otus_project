using AccuMicroService.Models;

namespace AccuMicroService.Interfaces
{
    public interface IAccuWeatherApiService
    {
        //public async Task<string> GetCityByGeoLocationAsync(string apiKey, GeoPositionModel geoPosition)            
        Task<string> GetCityByNameAsync(string сityName, string langauage = "ru", bool details = true);
        Task<List<WeatherCalendarModel>> GetWeatherByLocationKeyAsync(string cityId, int dayQuantity, string language = "ru", bool metric = true);
        Task<string> GetCityByGeoLocationAsync(GeoPositionModel geoPosition);
        Task<DateTime> PrecipitationLastDateAsync(string accuCityId);
    }
}
