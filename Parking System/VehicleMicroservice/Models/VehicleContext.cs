using Microsoft.EntityFrameworkCore;

namespace VehicleMicroservice.Models
{
    public class VehicleContext:DbContext
    {
        public VehicleContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
