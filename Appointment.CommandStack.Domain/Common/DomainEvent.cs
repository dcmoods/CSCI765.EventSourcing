using System;

namespace Appointment.Domain.Common
{
    public class DomainEvent 
    {
        public DateTime TimeStamp { get; private set; }

        public DomainEvent()
        {
            TimeStamp = DateTime.Now;
        }
    }
}