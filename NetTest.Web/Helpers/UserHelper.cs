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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserAsync(User User, string password)
        {
            return await _userManager.CreateAsync(User, password);
        }

        public async Task AddUserToRoleAsync(User User, string roleName)
        {
            await _userManager.AddToRoleAsync(User, roleName);
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

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(User User, string roleName)
        {
            return await _userManager.IsInRoleAsync(User, roleName);
        }

        Task<IdentityResult> IUserHelper.AddUserAsync(User User, string password)
        {
            throw new NotImplementedException();
        }
    }

}
