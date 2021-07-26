using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT_1.Models
{
    public class Privilege
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}