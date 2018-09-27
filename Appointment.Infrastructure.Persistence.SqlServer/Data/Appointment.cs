using System;
using System.Collections.Generic;

namespace Appointment.Infrastructure.Persistence.SqlServer.Data
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string RequestId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public int StartingAt { get; set; }
        public int Length { get; set; }
        public string Notes { get; set; }

        public Room Room { get; set; }
    }
}
