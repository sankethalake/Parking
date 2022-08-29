﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSlots.Models;
using ParkingSlots.Models.Repository;
using System.Collections.Generic;

namespace ParkingSlots.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotRepository<Slot> _dataRepository;
        public SlotController(ISlotRepository<Slot> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Slot> slot = _dataRepository.GetAll();
            return Ok(slot);
        }
        // GET: api/Employee/5
        [HttpGet("getSlot/{id}", Name = "GetSlot")]
        public IActionResult GetSlot(int id)
        {
            Slot slot = _dataRepository.Get(id);
            if (slot == null)
            {
                return NotFound("The Slot record couldn't be found.");
            }
            return Ok(slot);
        }

        // GET: api/Employee/5
        [HttpGet("getParkedSlots",Name = "getParkedSlots")]
        public IActionResult GetParkedSlots()
        {
            IEnumerable<Slot> slot = _dataRepository.GetParkedSlots();
            if (slot == null)
            {
                return NotFound("The Slot record couldn't be found.");
            }
            return Ok(slot);
        }

        // GET: api/Employee/5
        [HttpGet("getUnparkedSlots", Name = "getUnparkedSlots")]
        public IActionResult GetUnparkedSlots()
        {
            IEnumerable<Slot> slot = _dataRepository.GetUnparkedSlots();
            if (slot == null)
            {
                return NotFound("The Slot record couldn't be found.");
            }
            return Ok(slot);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Slot slot)
        {
            if (slot == null)
            {
                return BadRequest("Slot is null.");
            }
            _dataRepository.Add(slot);
            return Ok(new {message="Slot Created"});
        }

        //PUT: api/Employee/5
        [HttpPut()]
        public IActionResult Put([FromBody] Slot slot)
        {
            if (slot == null)
            {
                return BadRequest("Slot is null.");
            }
            Slot slotToUpdate = _dataRepository.Get(slot.SlotID);
            if (slotToUpdate == null)
            {
                return NotFound("The Slot record couldn't be found.");
            }
            _dataRepository.Update(slotToUpdate, slot);
            return NoContent();
        }

        //DELETE: api/Employee/5
        [HttpDelete()]
        public IActionResult Delete(int slotId)
        {
            Slot slot = _dataRepository.Get(slotId);
            System.Console.WriteLine(slotId);
            if (slot == null)
            {
                return NotFound("Slot not found.");
            }
            _dataRepository.Delete(slot);
            return Ok(new {message="Slot Deleted"});
        }
    }
}
