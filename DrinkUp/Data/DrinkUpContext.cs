using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DrinkUp.Models;

namespace DrinkUp.Data
{
    public class DrinkUpContext : DbContext
    {
        public DrinkUpContext(DbContextOptions<DrinkUpContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tea>()
                .HasKey(c => c.TeaID);
            modelBuilder.Entity<TeaIngredient>()
                .HasKey(c => c.TeaIngredientID);
            modelBuilder.Entity<TeaIngredientLink>()
                .HasKey(c => new {c.TeaId, c.TeaIngredientID });
            modelBuilder.Entity<TeaStore>()
                .HasKey(c => c.TeaStoreID);
            modelBuilder.Entity<TeaStoreLink>()
                .HasKey(c => new { c.TeaId, c.TeaStoreId });
            modelBuilder.Entity<TeaTags>()
                .HasKey(c => c.TeaTagID);
            modelBuilder.Entity<TeaTagsLink>()
                .HasKey(c => new { c.TeaId, c.TeaTagID });
        }

        public DbSet<DrinkUp.Models.Tea> Tea { get; set; }

        public DbSet<DrinkUp.Models.TeaIngredient> TeaIngredient { get; set; }

        public DbSet<DrinkUp.Models.TeaIngredientLink> TeaIngredientLink { get; set; }

        public DbSet<DrinkUp.Models.TeaStore> TeaStore { get; set; }

        public DbSet<DrinkUp.Models.TeaStoreLink> TeaStoreLink { get; set; }

        public DbSet<DrinkUp.Models.TeaTags> TeaTags { get; set; }

        public DbSet<DrinkUp.Models.TeaTagsLink> TeaTagsLink { get; set; }
    }
}
