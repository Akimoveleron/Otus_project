namespace AccuMicroService.Enitites;

public partial class RReestrObject
{

    /// <summary>
    /// справочник адресных  объектов ( города,  населенные пункты )  
    /// </summary>
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? AccuweatherId { get; set; }

    public virtual ICollection<WeatherCalendar> WeatherCalendars { get; set; } = new List<WeatherCalendar>();
}
