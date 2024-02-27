using System.Net;

namespace AccuWeatherApi
{
    /// <summary>
    /// Класс для получения города по широте и долготе
    /// </summary>
    public class APIMethods
    {
        private readonly UserApi userApi = new();

        /// <summary>
        /// Метод для получения id и наименования города
        /// </summary>
        /// <param name="geoPosition"></param>
        /// <param name="langauage"></param>
        /// <param name="details"></param>
        /// <param name="toplevel"></param>
        public void GetCityFromServices(GeoPosition geoPosition, string langauage = "ru", bool details = true, bool toplevel = false)
        {
            string apiKey = userApi.UserApiProperty;
            string latLon = String.Concat(geoPosition.Latitude, ",", geoPosition.Longitude);
            //43.2380, 76.8829
            try
            {
                string jsonOnWeb = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={latLon}&language={langauage}&details={details}&toplevel={toplevel}";
                WebClient webClient = new();
                string prepareString = webClient.DownloadString(jsonOnWeb);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Метод реализует получение списка городов
        /// </summary>
        /// <param name="сityName"></param>
        /// <param name="langauage"></param>
        /// <param name="details"></param>
        public void GetCityFromServices(string сityName, string langauage = "ru", bool details = true)
        {
            string apiKey = userApi.UserApiProperty;
            try
            {
                string jsonOnWeb = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={сityName}&language={langauage}&details={details}";
                WebClient webClient = new();
                string prepareString = webClient.DownloadString(jsonOnWeb);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Метод реализует получение погоды на 1/5/10/15 дней
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="dayQuantity"></param>
        /// <param name="language"></param>
        /// <param name="metric"></param>
        public void GetWeatherFromServices(int cityId, int dayQuantity, string language = "ru", bool metric = true)
        {
            string apiKey = userApi.UserApiProperty;
            string days = String.Concat(dayQuantity,"day/");
            try
            {
                string jsonOnWeb = $"http://dataservice.accuweather.com/forecasts/v1/daily/{days}&{cityId}&apikey={apiKey}&language={language}&metric={metric}";
                WebClient webClient = new();
                string prepareString = webClient.DownloadString(jsonOnWeb);
            }
            catch
            {

            }
        }


    }
}
