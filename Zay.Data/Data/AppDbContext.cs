using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.Data.Models;

namespace Zay.Data.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasKey(p => p.Id);
            builder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(125)
                .IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Brand)
                .HasMaxLength(125)
                .IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Size)
                .IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Color)
                .HasMaxLength(125);
            builder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250);

            builder.Entity<Category>()
                .HasKey(c => c.Id);
            builder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(125)
                .IsRequired();
            builder.Entity<Category>()
                .HasData(
                    new { Id = 1, Name = "Shim" },
                    new { Id = 2, Name = "Oyoq kiyim" },
                    new { Id = 3, Name = "Ust kiyim" },
                    new { Id = 4, Name = "Ko'ylak" },
                    new { Id = 5, Name = "Vetrofka" },
                    new { Id = 6, Name = "Bosh kiyim" },
                    new { Id = 7, Name = "Ko'zoynak" },
                    new { Id = 8, Name = "Ich kiyim" }
                );
            base.OnModelCreating(builder);
        }
    }
}
