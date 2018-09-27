using System;
using System.Collections.Generic;

namespace Appointment.Infrastructure.Persistence.SqlServer.Data
{
    public partial class Room
    {
        public Room()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstSlot { get; set; }
        public int LastSlot { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
