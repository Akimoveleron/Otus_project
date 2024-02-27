using Domain.BaseEntites;

namespace Domain.Models
{
    public class RoleModel : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
