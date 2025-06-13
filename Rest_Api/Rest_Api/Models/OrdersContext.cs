using Microsoft.EntityFrameworkCore;
using Rest_Api.Models;

public class OrdersContext : DbContext
{
    public OrdersContext(DbContextOptions options) : base(options) { }
 
    public DbSet<Assortment> Products { get; set; }
    public DbSet<OrdersRegistration> Orders { get; set; }
}