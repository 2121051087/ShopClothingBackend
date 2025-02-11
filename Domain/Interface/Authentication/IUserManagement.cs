using ShopClothing.Domain.Entities.Identity;
using System.Security.Claims;

namespace ShopClothing.Domain.Interface.Authentication
{
    public interface IUserManagement
    {
        Task<bool> RegisterUser(AppUser user);
        Task<bool> LoginUser(AppUser user);

        Task<AppUser?> GetUserByEmail(string email);
        Task<AppUser> GetUserById(string id);
        Task<IEnumerable<AppUser>?> GetAllUser();
        Task<int> RemoveUserByEmail(string email);
        Task<List<Claim>> GetUserClaims(string email);
    }
}
