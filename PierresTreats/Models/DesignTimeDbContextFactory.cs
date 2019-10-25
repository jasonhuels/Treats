using Microsoft.EntityFramework;
using Microsoft.EntityFramework.Design;
using Microsoft.Etensions.Configuration;
using System.IO;

namespace PierresTreats.Models
{
    public class PierresTreatsContextFactory : IDesignTimeDbContextFactory<PierresTreatsContext>
    {
        PierresTreatsContext IDesignTimeDbContextFactory<PierresTreatsContext>.CreateDbContext(stringp[] args)
        {
            IconfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<PierresTreatsContextFactory>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseMySql(connectionString);
            return new PierresTreatsContext(builder.Options);
        }
    }
}