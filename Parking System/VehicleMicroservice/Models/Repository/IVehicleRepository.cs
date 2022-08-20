using System.Collections.Generic;

namespace VehicleMicroservice.Models.Repository
{
    public interface IVehicleRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string vehicleNumber);
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
