using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSlots.Models
{
    public class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int SlotID { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public Boolean IsParked{ get; set; }
        [Required]
        public VehicleType Type { get; set; }

    }
    public enum VehicleType
    {
        Two_Wheeler,
        Four_Wheeler,
    }
}
