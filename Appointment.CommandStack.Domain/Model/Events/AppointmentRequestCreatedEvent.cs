using Appointment.Domain.Common;

namespace Appointment.Domain.Model.Events
{
    public class AppointmentRequestCreatedEvent : DomainEvent
    {
        public AppointmentRequestCreatedEvent(int roomid, int startHour, int length, string name, string notes)
        {
            RoomId = roomid;
            StartHour = startHour;
            Length = length;
            Name = name;
            Notes = notes;
        }

        public int RoomId { get; private set; }
        public int StartHour { get; private set; }
        public int Length { get; private set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
