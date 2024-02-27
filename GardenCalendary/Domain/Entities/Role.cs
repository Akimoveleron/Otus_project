using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? NormalizedName { get; set; }
    }
}
