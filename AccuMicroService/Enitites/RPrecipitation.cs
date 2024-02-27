namespace AccuMicroService.Enitites;

public partial class RPrecipitation
{
    /// <summary>
    ///  справочник осадков
    /// </summary>
    public int Id { get; set; }

    public string? Precipitation { get; set; } //описание осадка  солнечно ,  дождь... снег
}
