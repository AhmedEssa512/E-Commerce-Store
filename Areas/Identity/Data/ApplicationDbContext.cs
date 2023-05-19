using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApplication.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


    public DbSet<Cart> carts { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<Offer> offers { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<OrderDetail> orderDetails { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Stock> stocks { get; set; }
}
