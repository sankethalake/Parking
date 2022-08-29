﻿using System.Collections.Generic;

namespace Parking.Models.Repositoy
{
    public interface IParkingRepository<TEntity>
    {
        TEntity Get(int id);
        void AddParking(TEntity parking);
        void UpdateParking(TEntity parking, TEntity entity);
        IEnumerable<TEntity> GetAllParking();
        //IEnumerable<TEntity> GetByVehicle(Vehicle Vehicle);
        TEntity GetBySlot(int slotId);


    }
}
