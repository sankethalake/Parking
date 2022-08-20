using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Vehicle.Models
{
    public class VehicleContext:DbContext
    {
        public VehicleContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
