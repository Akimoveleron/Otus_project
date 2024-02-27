using Domain.BaseEntites;

namespace Domain.Entities
{
    public class UserGarden : BaseEntity
    {
        /// <summary>
        /// связь пользователя и сада 
        /// </summary>
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int GardenId { get; set; }
        public Garden? Garden { get; set; }
    }
}
