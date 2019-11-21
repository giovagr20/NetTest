using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Web.Data.Entities
{
    public class Manager
    {
        public int Id { get; set; }

        public SuperUser SuperUser { get; set; }
    }

}
}
