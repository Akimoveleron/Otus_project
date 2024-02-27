using Domain.BaseEntites;

namespace Domain.Models
{
    public class UserGardenModel : BaseModel
    {
        /// <summary>
        /// связь пользователя и сада 
        /// </summary>
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GardenId { get; set; }
    }
}
