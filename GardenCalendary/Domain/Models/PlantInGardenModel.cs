using Domain.BaseEntites;

namespace Domain.Models
{
    public class PlantInGardenModel :  BaseModel
    {
        public int Id { get; set; }
        
        public int GardenId { get; set; }

        public int RPlantId { get; set; }

        public DateTime? DatePlanting { get; set; }

        public DateTime? DateWatering { get; set; }

        public DateTime? DateHoeing { get; set; }

        public DateTime? DateLoosening { get; set; }

        public DateTime? DateWeeding { get; set; }

        public DateTime? DateHarvesting { get; set; }

        public bool? NotificationOnTelegram { get; set; }
    }
}
