using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedDomain.Entities;

namespace SharedDomain.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
        
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (!builder.IsConfigured)
        {
            builder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
        
        base.OnConfiguring(builder);
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Allergen> Allergens { get; set; }
}