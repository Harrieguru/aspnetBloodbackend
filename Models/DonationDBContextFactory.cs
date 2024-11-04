using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace webAPI.Models
{
    public class DonationDBContextFactory : IDesignTimeDbContextFactory<DonationDBContext>
    {
        public DonationDBContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContextOptionsBuilder for PostgreSQL
            var builder = new DbContextOptionsBuilder<DonationDBContext>();
            var connectionString = configuration.GetConnectionString("DevConnection");

            // Use Npgsql with the connection string from appsettings.json
            builder.UseNpgsql(connectionString);

            return new DonationDBContext(builder.Options);
        }
    }
}
