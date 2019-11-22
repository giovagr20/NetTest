using Microsoft.AspNetCore.Identity;
using NetTest.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User User, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User User, string roleName);

        Task<bool> IsUserInRoleAsync(User User, string roleName);

    }
}
