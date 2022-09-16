using System.Collections.Generic;

namespace Parking.Models.Repositoy
{
    public interface IParkingRepository<TEntity>
    {
        // Returns Parking By Id from database
        TEntity Get(int id);

        // Add Parking Object in Database
        void AddParking(TEntity parking);

        // Update Parking in database if Present
        void UpdateParking(TEntity parking, TEntity entity);

        // Get All The Parkings By Vehicle
        IEnumerable<TEntity> GetAllParking();
        //IEnumerable<TEntity> GetByVehicle(Vehicle Vehicle);

        // Get Parking By Slot
        TEntity GetBySlot(int slotId);


    }
}
