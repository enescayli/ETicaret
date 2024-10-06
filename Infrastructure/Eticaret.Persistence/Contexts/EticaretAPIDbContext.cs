using Eticaret.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistence.Contexts;

public class EticaretApiDbContext : DbContext
{
    public EticaretApiDbContext(DbContextOptions<EticaretApiDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
}