using Appointment.Infrastructure.Framework;

namespace Appointment.CommandStack.Commands
{
    public class RequestAppointmentCommand : Command
    {
        public RequestAppointmentCommand(int roomId, int startHour, int length, string userName, string notes)
        {
            Name = "AddAppointment";
            RoomId = roomId;
            StartHour = startHour;
            Length = length;
            UserName = userName;
            Notes = notes;
        }

        public int RoomId { get; private set; }
        public int StartHour { get; private set; }
        public int Length { get; private set; }
        public string UserName { get; private set; }
        public string Notes { get; private set; }
    }
}
