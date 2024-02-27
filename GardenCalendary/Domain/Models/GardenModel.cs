using Domain.BaseEntites;

namespace Domain.Models
{
    /// <summary>
    /// Сад
    /// </summary>
    public class GardenModel : BaseModel
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Ближайший населенный пункт где находится сад
        /// </summary>
        public long ObjectId { get; set; }

        /// <summary>
        /// Наименование огорода
        /// </summary>
        public string Name { get; set; }

    }
}
