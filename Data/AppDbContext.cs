using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDN.Data
{
     public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection") 
    {
    }
        public DbSet<User> Users { get; set; }
    }
}