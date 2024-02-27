namespace AccuMicroService.Enitites;

public class WeatherCalendar
{
    public int Id { get; set; }

    public int? ObjectId { get; set; }

    public DateTime? DateTime { get; set; }

    //public int? PrecipitationId { get; set; }
    public string? Precipitation { get; set; }

    public int? TemperaturaMax { get; set; }

    public int? TemperaturaMin { get; set; }

    public virtual RReestrObject? Object { get; set; }

    //public virtual RPrecipitation? Precipitation { get; set; }
}
