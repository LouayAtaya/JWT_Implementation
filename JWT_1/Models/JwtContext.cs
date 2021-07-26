using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JWT_1.Models
{
    public class JwtContext : DbContext
    {
        public JwtContext():base("DefaultConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Privilege> Privileges { get; set; }

    }
}