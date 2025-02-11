using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Interface.Authentication;
using ShopClothing.Infrastructure.Data;
using System.Security.Claims;

namespace ShopClothing.Infrastructure.Repositories.Authentication
{
    public class UserManagementRepository(IRoleManagement roleManagement,
        UserManager<AppUser> userManager, AppDbContext context) : IUserManagement
    {
        public async Task<IEnumerable<AppUser>?> GetAllUser() => await context.Users.ToListAsync();


        public async Task<AppUser?> GetUserByEmail(string email) => await userManager.FindByEmailAsync(email);


        public async Task<AppUser> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user!;
        }

        public async Task<List<Claim>> GetUserClaims(string email)
        {
            var _user = await GetUserByEmail(email);
            string? roleName = await roleManagement.GetUserRole(_user!.Email!);

            List<Claim> claim = [
                new Claim("FullName", _user!.FullName!),
                new Claim(ClaimTypes.NameIdentifier, _user!.Id),
                new Claim(ClaimTypes.Email, _user!.Email!),
                new Claim(ClaimTypes.Role, roleName!)
                ];
            return claim;
        }

        public async Task<bool> LoginUser(AppUser user)
        {
            AppUser? _user = await GetUserByEmail(user.Email!);
            if (_user is null) return false;


            string? roleName = await roleManagement.GetUserRole(_user!.Email!);
            if (string.IsNullOrEmpty(roleName)) return false;

            return await userManager.CheckPasswordAsync(_user!, user.PasswordHash!);
        }

        public async Task<bool> RegisterUser(AppUser user)
        {
            AppUser? _user = await GetUserByEmail(user.Email!);
            if (_user != null) return false;

            return (await userManager.CreateAsync(user!, user!.PasswordHash!)).Succeeded;

        }

        public async Task<int> RemoveUserByEmail(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            context.Users.Remove(user!);
            return await context.SaveChangesAsync();
        }
    }
}
