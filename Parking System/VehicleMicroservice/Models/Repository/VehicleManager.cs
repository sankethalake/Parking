using System.Collections.Generic;
using System.Linq;

namespace VehicleMicroservice.Models.Repository
{
    public class VehicleManager: IVehicleRepository<Vehicle>
    {
        readonly VehicleContext _vehicleContext;
        public VehicleManager(VehicleContext context)
        {
            _vehicleContext = context;
        }
        public void Add(Vehicle entity)
        {
            _vehicleContext.Vehicles.Add(entity);
            _vehicleContext.SaveChanges();
        }

        public void Delete(Vehicle entity)
        {
            _vehicleContext.Vehicles.Remove(entity);
            _vehicleContext.SaveChanges();
        }

        public Vehicle Get(string vehicleNumber)
        {
            return _vehicleContext.Vehicles.FirstOrDefault(v => v.VehicleNumber == vehicleNumber);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicleContext.Vehicles.ToList();
        }
    }
}
