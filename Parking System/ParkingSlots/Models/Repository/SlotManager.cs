using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingSlots.Models.Repository
{
    public class SlotManager : ISlotRepository<Slot>
    {
        readonly SlotContext _slotContext;
        public SlotManager(SlotContext context)
        {
            _slotContext = context;
        }

        //returns all slots
        public IEnumerable<Slot> GetAll()
        {
            return _slotContext.Slots.ToList();
        }

        //returns all parked slots
        public IEnumerable<Slot> GetParkedSlots()
        {
            return _slotContext.Slots.Where(s => s.IsParked == true);
        }

        //returns all unparked slots
        public IEnumerable<Slot> GetUnparkedSlots()
        {
            return _slotContext.Slots.Where(s => s.IsParked == false);
        }

        public Slot Get(long id)
        {
            return _slotContext.Slots
                  .FirstOrDefault(e => e.SlotID == id);
        }
        public void Add(Slot entity)
        {
            _slotContext.Slots.Add(entity);
            _slotContext.SaveChanges();
        }
        public void Update(Slot slot, Slot entity)
        {
            slot.SlotID = entity.SlotID;
            slot.Floor = entity.Floor;
            slot.IsParked = entity.IsParked;
            slot.Type = entity.Type;
            _slotContext.SaveChanges();
        }
        public void Delete(Slot slots)
        {
            _slotContext.Slots.Remove(slots);
            _slotContext.SaveChanges();
        }
    }    
}
