using System.Collections.Generic;

namespace ParkingSlots.Models.Repository
{
    public interface ISlotRepository<TEntity>
    {
            // Get all Slots in the dataase
            IEnumerable<TEntity> GetAll();
        // Gets all parked Slots
            IEnumerable<TEntity> GetParkedSlots();
        // Gets all unparked Slots
            IEnumerable<TEntity> GetUnparkedSlots();
        // get Slot by id from database
            TEntity Get(long id);
        // Add new Slot in the database
            void Add(TEntity entity);
        // Deletes a Slot from database
            void Delete(TEntity entity);
        // Updates existing Slot with given slot
            void Update(TEntity dbEntity, TEntity entity);
    }
}
