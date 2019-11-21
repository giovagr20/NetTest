using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetTest.Web.Data.Entities
{
    public class User
    {
        public SuperUser SuperUser { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
