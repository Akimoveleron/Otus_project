
namespace GardeningTipsService.Entities;

public class WeatherCalendar
{
    public int Id { get; set; }

    public int? ObjectId { get; set; }

    public DateTime? DateTame { get; set; }

    public int? PrecipitationId { get; set; }

    public int? TemperaturaMax { get; set; }

    public int? TemperaturaMin { get; set; }

    public virtual RReestrObject? Object { get; set; }
}
