using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking.Models.Repositoy;
using Parking.Models;
using System.Collections.Generic;


namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        // Parking Repository object to call repository methods
        public readonly IParkingRepository<Models.Parking> _dataRepository;
        public ParkingController(IParkingRepository<Models.Parking> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Parking
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Parking> parking= _dataRepository.GetAllParking();
            return Ok(parking);
        }

        // POST: api/Parking
        [HttpPost]
        public IActionResult Post([FromBody] Models.Parking parking)
        {
            if (parking == null)
            {
                return BadRequest("Slot is null.");
            }
            _dataRepository.AddParking(parking);
            return Ok(new { message = "Parking allocated" });
        }

        //PUT: api/Parking/5
        [HttpPut()]
        public IActionResult Put([FromBody] Models.Parking parking)
        {
            if (parking == null)
            {
                return BadRequest("Slot is null.");
            }
            Models.Parking parkingToUpdate = _dataRepository.Get(parking.Id);
            if (parkingToUpdate == null)
            {
                return NotFound("The Slot record couldn't be found.");
            }
            _dataRepository.UpdateParking(parkingToUpdate, parking);
            return NoContent();
        }

        //GET: api/Parking/5

        [HttpGet("{getBySlot}")]
            public IActionResult GetBySlot(int getBySlot)
        {
            Models.Parking parking = _dataRepository.GetBySlot(getBySlot);
            return Ok(parking);
        }

        //    // GET: api/Employee
        //    [HttpGet()]
        //    public IActionResult GetByVehicle([FromBody] Vehicle vehicle)
        //    {
        //        IEnumerable<Models.Parking> slot = _dataRepository.GetByVehicle(vehicle);
        //        return Ok(slot);
        //    }
        //    // GET: api/Employee/5
    }
}
