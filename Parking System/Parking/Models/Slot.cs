using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SlotID { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public Boolean IsParked{ get; set; }
        [Required]
        public SlotType Type { get; set; }

    }
    public enum SlotType
    {
        Two_Wheeler,
        Four_Wheeler,
    }
}
