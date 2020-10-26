using DNBProject.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.DAL.DatabaseContext
{
    public class DNBProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"/////**************Connection String**************/////");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.IDOrder)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<PaymentType>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.PaymentType)
                .HasForeignKey(e => e.IDPaymentType)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ShoppingCart>()
            .HasOne<Order>(e => e.Order)
            .WithOne(e => e.ShoppingCart)
            .HasForeignKey<ShoppingCart>(ad => ad.ID);

            modelBuilder.Entity<CartItem>().HasKey(e => new { e.IDProduct, e.IDShoppingCart });



            modelBuilder.Entity<Product>()
                .HasMany(e => e.CartItems)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.IDProduct)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.IDProduct)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithOne(e => e.ProductType)
                .HasForeignKey(e => e.IDProductType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoppingCart>()
                .HasMany<CartItem>(e => e.CartItems)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey(e => e.IDShoppingCart)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<User>()
                .HasMany<ShoppingCart>(e => e.ShoppingCarts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserID);
        }


        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
