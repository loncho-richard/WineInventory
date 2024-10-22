using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WineInventoryContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }

        public WineInventoryContext(DbContextOptions<WineInventoryContext> options) : base (options) 
        {
            
        }
    }
}
