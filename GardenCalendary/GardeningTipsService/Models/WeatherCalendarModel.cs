namespace GardeningTipsService.Models
{
    public  class WeatherCalendarModel
    {
        public int Id { get; set; }

        public int? ObjectId { get; set; }

        public DateTime? DateTime { get; set; }

        public string? Precipitation { get; set; }

        public int? TemperaturaMax { get; set; }

        public int? TemperaturaMin { get; set; }

    }
}
