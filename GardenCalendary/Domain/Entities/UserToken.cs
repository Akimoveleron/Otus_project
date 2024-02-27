using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class UserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
