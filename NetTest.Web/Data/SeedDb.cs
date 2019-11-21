using NetTest.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUsersAsync();
        
        }

        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                AddUser("123456", "Giovanni", "Gomez", 25, "Male", "Colombian");
                AddUser("123456", "Isabel", "Gomez", 26, "Female", "Colombian");
                AddUser("123456", "Lina", "Restrepo", 42, "Female", "Colombian");
                await _context.SaveChangesAsync();
            }
        }

        private void AddUser(
            string document,
            string firstName,
            string lastName,
            int age,
            string gender,
            string nationality)
        {
            _context.Users.Add(new User
            {
                Nationality = nationality,
                Gender = gender,
                Document = document,
                FirstName = firstName,
                Age = age,
                LastName = lastName
            });
        }
    }
}
