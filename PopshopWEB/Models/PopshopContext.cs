using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PopshopWEB
{
    public partial class PopshopContext : DbContext
    {
        public PopshopContext()
            : base("name=PopshopModelDB")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Item)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Item>()
                .Property(e => e.Amount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photos>()
                .Property(e => e.ImageFormat)
                .IsUnicode(false);
        }
    }
}
