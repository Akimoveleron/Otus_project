using Application.Interfaces.Services;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GardenCalendaryApi.Controllers
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

        [Route("GetCityByName")]
        [HttpPost]
        public async Task<ActionResult<string>> GetCityByName(string cityName)
        {
            return Ok(await _apiService.GetCityByNameAsync(cityName));
        }
    }
}
