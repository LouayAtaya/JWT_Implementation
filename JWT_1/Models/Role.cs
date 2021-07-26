using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT_1.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<Privilege> Privileges { get; set; }
    }
}