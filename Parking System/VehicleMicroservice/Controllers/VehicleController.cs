using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleMicroservice.Models;
using VehicleMicroservice.Models.Repository;

namespace VehicleMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository<Vehicle> _dataRepository;
        public VehicleController(IVehicleRepository<Vehicle> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Vehicle> vehicle = _dataRepository.GetAll();
            return Ok(vehicle);
        }
        // GET: api/Employee/5
        [HttpGet("{vehicleNumber}", Name = "Get")]
        public IActionResult Get(string vehicleNumber)
        {
            Vehicle vehicle = _dataRepository.Get(vehicleNumber);
            if (vehicle == null)
            {
                return NotFound("The Vehicle record couldn't be found.");
            }
            return Ok(vehicle);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle is null.");
            }
            _dataRepository.Add(vehicle);
            return Ok("Vehicle Created");
        }
        //PUT: api/Employee/5
        //[HttpPut("{id}")]
        //public IActionResult Put(string vehicleNumber, [FromBody] Vehicle vehicle)
        //{
        //    if (vehicle == null)
        //    {
        //        return BadRequest("Employee is null.");
        //    }
        //    Vehicle employeeToUpdate = _dataRepository.Get(id);
        //    if (employeeToUpdate == null)
        //    {
        //        return NotFound("The Employee record couldn't be found.");
        //    }
        //    _dataRepository.Update(employeeToUpdate, vehicle);
        //    return NoContent();
        //}
        // DELETE: api/Employee/5

        [HttpDelete()]
        public IActionResult Delete(string vehicleNumber)
        {
            Vehicle vehicle = _dataRepository.Get(vehicleNumber);
            if (vehicle == null)
            {
                return NotFound("The vehicle record couldn't be found.");
            }
            _dataRepository.Delete(vehicle);
            return NoContent();
        }
    }
}
