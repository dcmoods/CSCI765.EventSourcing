using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.QueryStack.Model
{
    public class RoomSchedule
    {
        public RoomSchedule()
        {
            Slots = new List<Slot>();
            RoomName = string.Empty;
        }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public IList<Slot> Slots { get; set; }
    }
}
