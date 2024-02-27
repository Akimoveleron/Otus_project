namespace GardeningTipsService.Entities
{
    /// <summary>
    /// Сад
    /// </summary>
    public class Garden
    {
        public int Id { get; set; }
        /// <summary>
        /// ближайший населенный пункт где находится сад
        /// </summary>
        public long ObjectId { get; set; } 

        public string Name { get; set; }

    }
}
