using Microsoft.EntityFrameworkCore;
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
            try
            {
                _parkingContext.Entry(parking).State = EntityState.Detached;
                //slot
                var existingSlot = _parkingContext.Slots.Local.SingleOrDefault(s => s.SlotID == parking.Slot.SlotID);
                if (existingSlot != null)
                {
                    parking.Slot = existingSlot;
                    _parkingContext.Entry(existingSlot).State = EntityState.Detached;
                }

                //vehicle
                var existingVehicle = _parkingContext.vehicles.Local.SingleOrDefault(s => s.VehicleNumber == parking.Vehicle.VehicleNumber);
                if (existingVehicle != null)
                {
                    parking.Vehicle = existingVehicle;
                    _parkingContext.Entry(existingVehicle).State = EntityState.Detached;
                }

                _parkingContext.Attach(parking);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                //_logger.Error(e.Message);
            }
            catch (System.InvalidOperationException e)
            {
                //_logger.Error(e.Message);
            }
            _parkingContext.Parking.Add(parking);
            _parkingContext.SaveChanges();
        }

        public Parking Get(int id)
        {
            return _parkingContext.Parking.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Parking> GetAllParking()
        {
            return _parkingContext.Parking.ToList();
        }

        public Parking GetBySlot(int slot)
        {
            return _parkingContext.Parking.FirstOrDefault(p => p.Slot.SlotID == slot);
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
