using Microsoft.EntityFrameworkCore;
using MetrixApi.Models;

namespace MetrixApi.Data
{
    public class MetrixDbContext : DbContext
    {
        public MetrixDbContext(DbContextOptions<MetrixDbContext> options)
            : base(options)
        {
        }

        public DbSet<BarcodeScan> BarcodeScans { get; set; }
    }
}