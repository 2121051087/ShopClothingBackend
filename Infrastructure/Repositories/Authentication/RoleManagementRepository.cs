using Microsoft.AspNetCore.Identity;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothing.Infrastructure.Repositories.Authentication
{
    public class RoleManagementRepository(UserManager<AppUser> userManager) : IRoleManagement
    {
        public async Task<bool> AddUserToRole(AppUser user, string roleName)
            =>(await userManager.AddToRoleAsync(user, roleName)).Succeeded;
       

        public async Task<string?> GetUserRole(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            return (await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }
    }
}
