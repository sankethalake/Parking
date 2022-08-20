using System.ComponentModel.DataAnnotations;

namespace VehicleMicroservice.Models
{
    public class Vehicle
    {
        [Key]
        [Required]
        [MaxLength(10, ErrorMessage = "VehicleNumber must be More than 7 characters or less than 11"), MinLength(7)]
        public string VehicleNumber { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public VehicleType Type { get; set; }
    }

    public enum VehicleType{
        Two_Wheeler,
        Four_Wheeler,
    }
}
