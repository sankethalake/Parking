using ParkingSlots.Models;
using System;
using VehicleMicroservice.Models;

namespace Parking.Models
{
    public class Parking
    {
        public Vehicle Vehicle { get; set; }
        public Slot ParkingSlots { get; set; }
        public DateTime ParkedTime { get; set; }
    }
}
