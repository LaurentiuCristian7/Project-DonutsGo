using DonutsGo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductUser> ProductUsers { get; set; }

        
        protected  override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ProductUser>()
                .HasKey(productUser => new { productUser.UserId, productUser.ProductId });

            modelBuilder.Entity<ProductUser>()
                .HasOne<Product>(x => x.Product)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ProductId);


            modelBuilder.Entity<ProductUser>()
              .HasOne<User>(x => x.User)
              .WithMany(x => x.Products)
              .HasForeignKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
