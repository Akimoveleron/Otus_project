using Domain.BaseEntites;

namespace Domain.Entities
{
    /// <summary>
    /// Сад.
    /// </summary>
    public class Garden : BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Ближайший населенный пункт где находится сад.
        /// </summary>
        public long ObjectId { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Посаженные растения в огороде.
        /// </summary>
        public List<PlantInGarden> PlantsInGarden { get; set; } = new List<PlantInGarden>();
    }
}
