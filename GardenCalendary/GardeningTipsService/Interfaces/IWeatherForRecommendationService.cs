namespace GardeningTipsService.Interfaces
{
    public interface IWeatherForRecommendationService
    {
        int? GetAccuweatherId(int gardenId);
        Task<int?> MinTemperaturaForFiveDays(int gardenId);
        Task<DateTime?> LastDayOfPrecipitation(int gardenId);
    }
}
