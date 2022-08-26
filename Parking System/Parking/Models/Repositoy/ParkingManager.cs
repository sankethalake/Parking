using System.Collections.Generic;
using System.Linq;


namespace Parking.Models.Repositoy
{
    public class ParkingManager : IParkingRepository<Parking>
    {
        public readonly ParkingContext _parkingContext;

        public ParkingManager(ParkingContext parkingContext)
        {
            _parkingContext = parkingContext;
        }
        public void AddParking(Parking parking)
        {
            _parkingContext.Parking.Add(parking);
            _parkingContext.SaveChanges();
        }

        public Parking Get(int id)
        {
            return _parkingContext.Parking.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Parking> GetBySlot(Parking parking)
        {
            return _parkingContext.Parking.Where(p => p.ParkingSlots == parking.ParkingSlots);
        }

        public IEnumerable<Parking> GetByVehicle(Vehicle vehicle)
        {
            return _parkingContext.Parking.Where(p => p.Vehicle == vehicle);
        }

        public void UpdateParking(Parking parking, Parking entity)
        {
            parking.UnparkedTime = entity.UnparkedTime;
            _parkingContext.SaveChanges();
        }
 
    }
}
