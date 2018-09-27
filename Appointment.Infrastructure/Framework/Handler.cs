using System;
using Appointment.Infrastructure.Framework.EventStore;

namespace Appointment.Infrastructure.Framework
{
    public abstract class Handler
    {
        public IEventStore EventStore { get; private set; }


        public Handler(IEventStore eventStore)
        {
            if (eventStore == null)
            {
                throw new ArgumentNullException("eventStore");
            }

            EventStore = eventStore;
        }
    }

}