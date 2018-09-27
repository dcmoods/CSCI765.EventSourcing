using Appointment.Infrastructure.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.CommandStack.Events
{
    public class AppointmentRejectedEvent : Event
    {
        public AppointmentRejectedEvent(Guid requestId, string reason = "")
        {
            RequestId = requestId;
            Reason = reason;
        }

        public Guid RequestId { get; private set; }
        public string Reason { get; private set; }
    }
}
