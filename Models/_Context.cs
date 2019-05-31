using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.API.CORE.Models
{
    public class _Context : DbContext
    { 
        public _Context(DbContextOptions<_Context> options)
           : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countrys { get; set; }
    }
}
