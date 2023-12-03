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
}