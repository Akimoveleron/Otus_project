using AccuMicroService.Enitites;
using AccuMicroService.Interfaces;
using AccuMicroService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace AccuMicroService
{
    public class AccuWeatherApiService : IAccuWeatherApiService
    {
        private readonly IApplicationDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly string apiKey = "";

        public AccuWeatherApiService(IApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            apiKey = _configuration["AccuWeatherApiKey"];
        }


        /// <summary>
        /// Метод реализует получение id и наименования города по геопозиции
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="geoPosition"></param>
        /// <returns></returns>
        public async Task<string> GetCityByGeoLocationAsync(GeoPositionModel geoPosition)
        {
            double latitude = geoPosition.Latitude;
            double longitude = geoPosition.Longitude;
            using (var client = new HttpClient())
            {
                string apiUrl = $"http://dataservice.accuweather.com/locations/v1/cities/geoposition/search?apikey={apiKey}&q={latitude}%2C{longitude}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                // Получение ответа и извлечение имени города
                string jsonResult = await response.Content.ReadAsStringAsync();

                var resultObject = JsonConvert.DeserializeObject<RootBasicCityInfo>(jsonResult);
                string city = "";
                if (resultObject != null)
                {
                    city = resultObject.LocalizedName;
                }
                else
                {
                    city = "Unknown";
                }
                return city;
            }
        }

        /// <summary>
        /// Метод реализует получение города по наименованию
        /// </summary>
        /// <param name="сityName"></param>
        /// <param name="langauage"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public async Task<string> GetCityByNameAsync(string сityName, string langauage = "ru", bool details = true)
        {
            var resultObjects = new List<RootBasicCityInfo>();
            using (var client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={сityName}&language={langauage}&details={details}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    // Получение ответа и извлечение имени города
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    resultObjects = JsonConvert.DeserializeObject<List<RootBasicCityInfo>>(jsonResult);
                }
                catch
                {
                    throw new Exception("Сервис погоды AccuWeather недоступен");
                }

                var city = resultObjects!.FirstOrDefault();

                string cityKey = "";
                if (city is not null)
                {
                    cityKey = city.Key;
                    var cityInDb = await _context.RReestrObjects.FirstOrDefaultAsync(r => r.AccuweatherId == city.Key);
                    if (cityInDb is null && !string.IsNullOrEmpty(city.Key) && city.Key != "0")
                    {
                        await _context.RReestrObjects.AddAsync(new RReestrObject
                        {
                            Id = 0,
                            AccuweatherId = city.Key,
                            Name = city.LocalizedName,
                        });
                        _context.SaveChanges();
                    }
                }
                else
                {
                    throw new NullReferenceException("Город не найден");
                }

                return cityKey;
            }

        }

        /// <summary>
        /// Метод реализует получение погоды на 1/5/10/15 дней
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="dayQuantity"></param>
        /// <param name="language"></param>
        /// <param name="metric"></param>
        public async Task<List<WeatherCalendarModel>> GetWeatherByLocationKeyAsync(string cityId, int dayQuantity, string language = "ru", bool metric = true)
        {
            var resObjects = new List<WeatherCalendarModel>();
            string jsonResult = string.Empty;
            var dayList = new List<int>
            {
                1,5
            };
            if (!dayList.Contains(dayQuantity))
            {
                dayQuantity = 1;
            }
            using (var client = new HttpClient())
            {
                var city = await _context.RReestrObjects.FirstOrDefaultAsync(x => x.AccuweatherId == cityId);
                if (city is null)
                {
                    throw new NullReferenceException("Город не найден в БД");
                }
                var weatherCalendar = await _context.WeatherCalendars.FirstOrDefaultAsync(x => x.ObjectId == city.Id
                    && x.DateTime.Value.Date == DateTime.UtcNow.Date.AddDays(dayQuantity - 1));
                if (weatherCalendar is not null)
                {
                    var list = await _context.WeatherCalendars.Where(x => x.ObjectId == city.Id
                        && x.DateTime.Value.Date >= DateTime.UtcNow.Date
                        && x.DateTime.Value.Date <= DateTime.UtcNow.Date.AddDays(dayQuantity - 1)).ToListAsync();
                    foreach (var entity in list)
                    {
                        resObjects.Add(new WeatherCalendarModel
                        {
                            Id = entity.Id,
                            DateTime = entity.DateTime,
                            ObjectId = entity.ObjectId,
                            Precipitation = entity.Precipitation,
                            TemperaturaMax = entity.TemperaturaMax,
                            TemperaturaMin = entity.TemperaturaMin
                        });
                    }
                    return resObjects;
                }
                try
                {
                    string apiUrl = $"http://dataservice.accuweather.com/forecasts/v1/daily/{dayQuantity}day/{cityId}?apikey={apiKey}&language={language}&metric={metric}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    // Получение ответа и извлечение имени города
                    jsonResult = await response.Content.ReadAsStringAsync();
                }
                catch
                {
                    throw new Exception("Сервис не доступен");
                }
                var rootWeather = JsonConvert.DeserializeObject<WeatherData>(jsonResult);
                if (rootWeather is not null)
                {
                    var dayForecasts = rootWeather;
                    if (dayForecasts is null)
                    {
                        throw new NullReferenceException("Погода не найдена");
                    }
                    foreach (var dailyForecast in dayForecasts.DailyForecasts)
                    {
                        //if (dailyForecast.Day.HasPrecipitation && !string.IsNullOrEmpty(dailyForecast.Day.PrecipitationType))
                        //{
                        //    var precInDb = await _context.RPrecipitations
                        //        .FirstOrDefaultAsync(x => dailyForecast.Day.PrecipitationType.Contains(x.Precipitation!));
                        //    if (precInDb is null)
                        //    {
                        //        await _context.RPrecipitations.AddAsync(new RPrecipitation
                        //        {
                        //            Precipitation = dailyForecast.Day.PrecipitationType
                        //        });
                        //        _context.SaveChanges();
                        //    }
                        //}

                        //if (dailyForecast.Night.HasPrecipitation && !string.IsNullOrEmpty(dailyForecast.Night.PrecipitationType))
                        //{
                        //    var precInDb = await _context.RPrecipitations
                        //        .FirstOrDefaultAsync(x => dailyForecast.Night.PrecipitationType.Contains(x.Precipitation!));
                        //    if (precInDb is null)
                        //    {
                        //        await _context.RPrecipitations.AddAsync(new RPrecipitation
                        //        {
                        //            Precipitation = dailyForecast.Night.PrecipitationType
                        //        });
                        //        _context.SaveChanges();
                        //    }
                        //}



                        //RPrecipitation? prec;
                        //if (dailyForecast.Night.HasPrecipitation && !string.IsNullOrEmpty(dailyForecast.Night.PrecipitationType))
                        //{
                        //    prec = await _context.RPrecipitations.FirstOrDefaultAsync(x => x.Precipitation == dailyForecast.Night.PrecipitationType);
                        //}
                        //else if (dailyForecast.Day.HasPrecipitation && !string.IsNullOrEmpty(dailyForecast.Day.PrecipitationType))
                        //{
                        //    prec = await _context.RPrecipitations.FirstOrDefaultAsync(x => x.Precipitation == dailyForecast.Day.PrecipitationType);
                        //}
                        //else
                        //{
                        //    prec = new RPrecipitation { Id = 0 };
                        //}
                        string? prec = null;
                        if (dailyForecast.Night.HasPrecipitation && !string.IsNullOrEmpty(dailyForecast.Night.PrecipitationType))
                        {
                            prec = dailyForecast.Night.PrecipitationType;
                        }
                        else if (dailyForecast.Day.HasPrecipitation && !string.IsNullOrEmpty(dailyForecast.Day.PrecipitationType))
                        {
                            prec = dailyForecast.Day.PrecipitationType;
                        }

                        var weather = new WeatherCalendar
                        {
                            Id = 0,
                            DateTime = dailyForecast.Date.ToUniversalTime(),
                            ObjectId = city.Id,
                            TemperaturaMax = Convert.ToInt32(dailyForecast.Temperature.Maximum.Value),
                            TemperaturaMin = Convert.ToInt32(dailyForecast.Temperature.Minimum.Value),
                            //PrecipitationId = prec!.Id is 0 ? null : prec.Id
                            Precipitation = prec
                        };
                        await _context.WeatherCalendars.AddAsync(weather);
                        _context.SaveChanges();
                        resObjects.Add(new WeatherCalendarModel
                        {
                            Id = weather.Id,
                            DateTime = weather.DateTime,
                            ObjectId = weather.ObjectId,
                            Precipitation = weather.Precipitation,
                            //PrecipitationId = weather.PrecipitationId,
                            TemperaturaMax = weather.TemperaturaMax,
                            TemperaturaMin = weather.TemperaturaMin
                        });
                    }
                }
                else
                {
                    throw new NullReferenceException("Погода не найдена");
                }

                return resObjects;
            }
        }

        /// <summary>
        /// Метод реализует получение из БД дату последних осадков по accuweather id города 
        /// </summary>
        /// <param name="accuCityId">accuweather id города</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<DateTime> PrecipitationLastDateAsync(string accuCityId)
        {
            var latestDate = await _context.WeatherCalendars
                .Include(x => x.Object)
                .Where(x => x.Object.AccuweatherId == accuCityId 
                && !string.IsNullOrEmpty(x.Precipitation)
                && x.DateTime <= DateTime.UtcNow)
                .MaxAsync(p => p.DateTime);

            if (latestDate != null && latestDate.HasValue)
            {
                return latestDate.Value;
            }
            else 
            {
                throw new NullReferenceException("Осадки не найдена");
            }
        }
    }
}
