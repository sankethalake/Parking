using ParkingSlots.Models;
using System;
using System.ComponentModel.DataAnnotations;
using VehicleMicroservice.Models;

namespace Parking.Models
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public Slot ParkingSlots { get; set; }
        public DateTime ParkedTime { get; set; }
        public DateTime UnparkedTime { get; set; }
    }
}
