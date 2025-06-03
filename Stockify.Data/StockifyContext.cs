using Stockify.Objects;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Stockify.Data;

public class StockifyContext : IdentityDbContext<ApplicationUser>
{
    public StockifyContext(DbContextOptions<StockifyContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<OrderAction> OrderActions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<StockAction> StockActions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed(); 
    }
}

