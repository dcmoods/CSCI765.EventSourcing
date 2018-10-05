using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.QueryStack.Model
{
    public class Slot
    {
        public Slot()
        {
            Name = "Staff";
            Notes = "[No notes]";
        }

        public int AppointmentId { get; set; }
        public int RoomId { get; set; }
        public int StartingAt { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public bool IsAvailable()
        {
            return Length == 0;
        }
    }
}
