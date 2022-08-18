using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSlots.Models
{
    public class SlotContext: DbContext
    {
        public SlotContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Slot> Slots { get; set; }
    }
}
