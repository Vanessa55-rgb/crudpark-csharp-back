using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CrudParking.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Operator> Operators { get; set; }
        public DbSet<VehicleMonthly> VehiclesM { get; set; }
        public DbSet<Monthly> Monthlies { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Pay> Pays { get; set; }
    }
}