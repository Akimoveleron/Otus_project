namespace AccuMicroService.Models
{
    public class RPrecipitationModel
    {
        /// <summary>
        ///  справочник осадков
        /// </summary>
        public int Id { get; set; }

        public string? Precipitation { get; set; } //описание осадка  солнечно ,  дождь... снег
    }
}
