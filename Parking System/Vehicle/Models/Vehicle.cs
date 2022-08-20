using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public class Vehicle
    {
        [Key]
        public string VehicleNumber { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }

    }
}
