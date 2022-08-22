using System.Collections.Generic;

namespace ParkingSlots.Models.Repository
{
    public interface ISlotRepository<TEntity>
    {
            IEnumerable<TEntity> GetAll();
            TEntity Get(long id);
            void Add(TEntity entity);
            void Delete(TEntity entity);
            void Update(TEntity dbEntity, TEntity entity);
    }
}
