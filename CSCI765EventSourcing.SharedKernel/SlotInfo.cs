using System;
using System.Collections.Generic;
using System.Text;

namespace CSCI765EventSourcing.SharedKernel
{
    public class SlotInfo
    {
        public string Action { get; set; }
        public int AppointmentId { get; set; }
        public int StartingAt { get; set; }
        public int RoomId { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime When { get; set; }
    }
}
