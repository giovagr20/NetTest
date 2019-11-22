using Microsoft.AspNetCore.Mvc;
using NetTest.Web.Data;
using NetTest.Web.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetTest.Web.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController
    {
        private readonly DataContext _dataContext;

        public CustomersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetOwnerByEmail")]
        public async Task<IActionResult> GetCustomerByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = await _dataContext.Customers
                .Include(o => o.User)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.User.Email.ToLower() == request.Email.ToLower());

            if (customer == null)
            {
                return NotFound();
            }

            var response = new CustomerResponse
            {
                Id = customer.Id,
                FirstName = customer.User.FirstName,
                LastName = customer.User.LastName,
                Age = customer.User.Age,
                Document = customer.User.Document,
                Email = customer.User.Email,
                Nationality = customer.User.Nationality,
                Gender = customer.User.Gender,
                Product = customer.Products?.Select(p => new ProductResponse
                {
                    Description = p.Description,
                    ItemsAmount = p.ItemsAmount
                })
            };

            return Ok(response);
        }

    }
}
