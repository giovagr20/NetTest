using Microsoft.AspNetCore.Identity;
using NetTest.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<SuperUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(
            UserManager<SuperUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserAsync(SuperUser superUser, string password)
        {
            return await _userManager.CreateAsync(superUser, password);
        }

        public async Task AddUserToRoleAsync(SuperUser superUser, string roleName)
        {
            await _userManager.AddToRoleAsync(superUser, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<SuperUser> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(SuperUser superUser, string roleName)
        {
            return await _userManager.IsInRoleAsync(superUser, roleName);
        }

        Task<IdentityResult> IUserHelper.AddUserAsync(SuperUser superUser, string password)
        {
            throw new NotImplementedException();
        }
    }

}
