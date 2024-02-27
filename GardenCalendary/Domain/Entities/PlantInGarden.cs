using Domain.BaseEntites;

namespace Domain.Entities
{
    public class PlantInGarden : BaseEntity
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

        public RPlant? Plant { get; set; }
        
        public Garden? Garden { get; set; }
    }
}