using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TastingWine>()
                .HasKey(tw => new { tw.WineId, tw.TastingWineId });

            modelBuilder.Entity<TastingWine>()
                .HasOne(tw => tw.Wine)
                .WithMany(w => w.TastingWine)
                .HasForeignKey(tw => tw.WineId);

            modelBuilder.Entity<TastingWine>()
                .HasOne(tw => tw.Tasting)
                .WithMany(wt => wt.TastingWine)
                .HasForeignKey(tw => tw.TastingWineId);
        }
    }
}
