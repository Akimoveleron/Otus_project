using Domain.Models;
using Npgsql.NameTranslation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAccuWeatherApiService
    {
        //public async Task<string> GetCityByGeoLocationAsync(string apiKey, GeoPositionModel geoPosition)            
        Task<string> GetCityByNameAsync(string сityName, string langauage = "ru", bool details = true);
        Task<string> GetWeatherByLocationKeyAsync(int cityId, int dayQuantity, string language = "ru", bool metric = true);
        Task<string> GetCityByGeoLocationAsync(string apiKey, GeoPositionModel geoPosition);
    }
}
