using Appointment.Domain.Common;
using Appointment.Domain.Model.Events;
using CSCI765EventSourcing.SharedKernel;
using System;

namespace Appointment.Domain.Model
{
    public class AppointmentRequest : Aggregate
    {
        protected AppointmentRequest()
        {
            Id = Guid.NewGuid();
        }

        public int RoomId { get; private set; }
        public int StartHour { get; private set; }
        public int Length { get; private set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; private set; }

        public void Apply(AppointmentRequestCreatedEvent evt)
        {
            RoomId = evt.RoomId;
            StartHour = evt.StartHour;
            Length = evt.Length;
            Name = evt.Name;
            Notes = evt.Notes;
        }

        public SlotInfo ToSlotInfo()
        {
            var slot = new SlotInfo();
            slot.RoomId = RoomId;
            slot.Length = Length;
            slot.Name = Name;
            slot.Notes = Notes;
            slot.StartingAt = StartHour;
            return slot;
        }

        public static class Factory
        {
            public static AppointmentRequest Create(int roomId, int startHour, int length, string name, string notes)
            {
                if (roomId <= 0)
                    throw new ArgumentException("Room id must not be 0.", nameof(roomId));
                if(startHour < 8 || startHour > 17)
                    throw new ArgumentException("Start hour must be between 08:00 and 17:00 hours.", nameof(startHour));
                if(length <= 0)
                    throw new ArgumentException("Appointment length must longer than 0.", nameof(length));
                if(length > 3)
                throw new ArgumentException("Appointment length must not be greater than 3 hours.", nameof(length));


                var requested = new AppointmentRequestCreatedEvent(roomId, startHour, length, name, notes);
                var request = new AppointmentRequest();
                request.RaiseEvent(requested);
                return request;

            }
        }
    }
}
