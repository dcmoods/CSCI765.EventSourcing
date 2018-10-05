using Appointment.Infrastructure.Framework;
using CSCI765EventSourcing.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.CommandStack.Events
{
    public class AppointmentUpdatedEvent : Event
    {
        public AppointmentUpdatedEvent()
        {

        }

        public AppointmentUpdatedEvent(int id, int roomId, int startHour, int length, string userName)
        {
            Id = id;
            When = DateTime.Now;
            SagaId = id;
            Data = new SlotInfo { RoomId = roomId, StartingAt = startHour, Length = length, Name = userName};
        }

        public int Id { get; set; }
        public DateTime When { get; set; }
        public SlotInfo Data { get; set; }
    }
}
