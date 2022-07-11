

using Microsoft.EntityFrameworkCore;
using RealProductShop.Data.Models;

namespace RealProductShop.Data;

public class ProductShopContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ProductShop;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(p => p.productsBought).WithOne(b => b.Buyer).HasForeignKey(b => b.BuyerId);
            entity.HasMany(p => p.productsSold).WithOne(b => b.Seller).HasForeignKey(b => b.SellerId);
        });

    }
}