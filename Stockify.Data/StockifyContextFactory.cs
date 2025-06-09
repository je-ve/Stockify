using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Stockify.Data
{
    public class StockifyContextFactory : IDesignTimeDbContextFactory<StockifyContext>
    {
        public StockifyContext CreateDbContext(string[] args)
        {
            // Build config from the main app's appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Stockify.Web"))
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<StockifyContext>();
            optionsBuilder.UseSqlServer(connectionString); // or UseSqlite / UseNpgsql etc.

            return new StockifyContext(optionsBuilder.Options);
        }
    }
}
