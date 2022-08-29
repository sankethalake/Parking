
using System;
using System.ComponentModel.DataAnnotations;


namespace Parking.Models
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Slot Slot { get; set; }
        public DateTime ParkedTime { get; set; }
        public DateTime UnparkedTime { get; set; }
    }
}
