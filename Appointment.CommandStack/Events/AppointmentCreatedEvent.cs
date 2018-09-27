using Appointment.Infrastructure.Framework;
using CSCI765EventSourcing.SharedKernel;
using System;

namespace Appointment.CommandStack.Events
{
    public class AppointmentCreatedEvent : Event
    {
        public AppointmentCreatedEvent()
        {
        }

        public AppointmentCreatedEvent(Guid requestId, int id, SlotInfo slotInfo)
        {
            RequestId = requestId;
            Id = id;
            When = DateTime.Now;
            Data = slotInfo;
            SagaId = id;
        }

        public Guid RequestId { get; set; }
        public int Id { get; set; }
        public DateTime When { get; set; }
        public SlotInfo Data { get; set; }
    }
}
