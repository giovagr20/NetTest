using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTest.Web.Data.Entities;

namespace NetTest.Web.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
