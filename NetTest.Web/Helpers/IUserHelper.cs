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
        Task<SuperUser> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(SuperUser superUser, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(SuperUser superUser, string roleName);

        Task<bool> IsUserInRoleAsync(SuperUser superUser, string roleName);

    }
}
