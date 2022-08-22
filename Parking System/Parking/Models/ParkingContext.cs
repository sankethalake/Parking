using Microsoft.EntityFrameworkCore;

namespace Parking.Models
{
    public class ParkingContext:DbContext
    {
        public ParkingContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Parking> Parking { get; set; }
    }
}
