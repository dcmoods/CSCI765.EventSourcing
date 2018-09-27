using System;
using System.Collections.Generic;

namespace Appointment.Infrastructure.EventStore.SqlServer.Data
{
    public partial class LoggedEvent
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int AggregateId { get; set; }
        public string Cargo { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
