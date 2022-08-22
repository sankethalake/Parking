using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking.Models.Repositoy;
using Parking.Models;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        public readonly IParkingRepository<Models.Parking> _dataRepository;
        public ParkingController(IParkingRepository<Models.Parking> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Models.Parking parking)
        {
            if (parking == null)
            {
                return BadRequest("Slot is null.");
            }
            _dataRepository.AddParking(parking);
            return Ok("Parking allocated");
        }

        //PUT: api/Employee/5
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
    }
}
