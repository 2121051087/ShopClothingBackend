using Microsoft.AspNetCore.Identity;


namespace ShopClothing.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
