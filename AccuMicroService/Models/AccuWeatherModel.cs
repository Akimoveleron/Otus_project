namespace AccuMicroService.Models
{
    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public long EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public long EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class MinimumMaximum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public MinimumMaximum Minimum { get; set; }
        public MinimumMaximum Maximum { get; set; }
    }

    public class DayNight
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
    }

    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public long EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public DayNight Day { get; set; }
        public DayNight Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class WeatherData
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
