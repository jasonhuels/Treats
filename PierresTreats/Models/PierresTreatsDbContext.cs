using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PierresTreats.Models
{
    public class PierresTreatsContext : IndentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Flavor> Flavors {get; set;}
        public DbSet<Treat> Treats {get; set;}
        public DbSet<FlavorTreat> FlavorTreats {get; set;}

        public PierresTreatsContext(DbContextOptions options) : base(options) {}
    }
}