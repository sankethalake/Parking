using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSlots.Models
{
    public class Slot
    {
        public int SlotID { get; set; }
        public string Floor { get; set; }
        public Boolean IsParked{ get; set; }
    }
}
