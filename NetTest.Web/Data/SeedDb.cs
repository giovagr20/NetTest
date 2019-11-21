using NetTest.Web.Data.Entities;
using NetTest.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            await CheckProductsAsync();

            var manager = await CheckSuperUserAsync("123456", "Giovanni", "Gomez", 25, "Male", "Colombian", "giovanni@yopmail.com","Manager");
            var user = await CheckSuperUserAsync("456789", "Isabel", "Gomez", 26, "Female", "Colombian", "isabel@yopmail.com","User");


        }

        private async Task CheckManagerAsync(SuperUser superUser)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { SuperUser = superUser });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<SuperUser> CheckSuperUserAsync(string document, 
            string firstName, 
            string lastName, 
            int age, 
            string gender,
            string nationality,
            string email,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new SuperUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    Nationality = nationality,
                    Gender = gender,
                    Age = age,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("User");
            
        }


        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                AddProduct("Product 1", "2 units");
                AddProduct("Product 2", "1 unit");
                AddProduct("Product 3", "50 units");
                AddProduct("Product 4", "1 unit");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(
            string description,
            string itemsAmount
            )
        {
            _context.Products.Add(new Product
            {
                Description = description,
                ItemsAmount = itemsAmount

            });
        }

    }
}
