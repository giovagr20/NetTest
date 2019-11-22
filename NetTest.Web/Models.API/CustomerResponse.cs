using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Web.Models.API
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }

        public string Email { get; set; }

        public ProductResponse Product { get; set; }
        public object User { get; internal set; }
    }
}
