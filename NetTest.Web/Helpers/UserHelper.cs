using Microsoft.AspNetCore.Identity;
using NetTest.Web.Data.Entities;
using NetTest.Web.Models;
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
        private readonly SignInManager<User> _signInManager;
        public UserHelper(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
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

        Task<User> IUserHelper.GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task IUserHelper.CheckRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        Task IUserHelper.AddUserToRoleAsync(User User, string roleName)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserHelper.IsUserInRoleAsync(User User, string roleName)
        {
            throw new NotImplementedException();
        }

        Task<SignInResult> IUserHelper.LoginAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        Task IUserHelper.LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }

}
