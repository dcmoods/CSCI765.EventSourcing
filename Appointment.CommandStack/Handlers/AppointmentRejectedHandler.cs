using Appointment.CommandStack.Events;
using Appointment.Infrastructure.Framework;
using Appointment.Infrastructure.Framework.EventStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.CommandStack.Handlers
{
    public class AppointmentRejectedHandler : Handler,
        IHandleMessage<AppointmentRejectedEvent>
    {
        public AppointmentRejectedHandler(IEventStore eventStore) 
            : base(eventStore)
        {
        }

        public void Handle(AppointmentRejectedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
