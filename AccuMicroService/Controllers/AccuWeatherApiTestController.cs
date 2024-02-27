using AccuMicroService.Interfaces;
using AccuMicroService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccuMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccuWeatherApiTestController : ControllerBase
    {
        private IAccuWeatherApiService _apiService { get; set; }

        public AccuWeatherApiTestController(IAccuWeatherApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("GetCityByName/{cityName}")]
        [HttpPost]
        public async Task<ActionResult<string>> GetCityByName(string cityName)
        {
            return Ok(await _apiService.GetCityByNameAsync(cityName));
        }
        /*
        [Route("GetWeatherByCityKey/{cityKey}")]
        [HttpPost]
        public async Task<ActionResult<string>> GetWeatherByCityKey(string cityKey, int days)
        {
            return Ok(await _apiService.GetWeatherByLocationKeyAsync(cityKey, days));
        }
        */
        [Route("GetWeatherByLocationKey/{locationKey}")]
        [HttpPost]
        public async Task<ActionResult<List<WeatherCalendarModel>>> GetWeatherByLocationKey(string locationKey, int days)
        {
            return Ok(await _apiService.GetWeatherByLocationKeyAsync(locationKey, days));
        }

        [Route("PrecipitationLastDate/{accuCityId}")]
        [HttpPost]
        public async Task<ActionResult<DateTime>> PrecipitationLastDate(string accuCityId)
        {
            return Ok(await _apiService.PrecipitationLastDateAsync(accuCityId));
        }

    }
}
