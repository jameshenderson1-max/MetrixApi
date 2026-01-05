using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MetrixApi.Models;

namespace MetrixApi.Data
{
    public class MetrixDbContextFactory : IDesignTimeDbContextFactory<MetrixDbContext>
    {
        public MetrixDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MetrixDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MetrixDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MetrixDbContext(optionsBuilder.Options);
        }
    }
}