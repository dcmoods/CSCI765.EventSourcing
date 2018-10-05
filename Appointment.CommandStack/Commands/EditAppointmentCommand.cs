using Appointment.Infrastructure.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.CommandStack.Commands
{
    public class EditAppointmentCommand : Command
    {
        public EditAppointmentCommand(int appointmentId, int roomId, int startHour, int length, string userName)
        {
            Name = "EditAppointment";
            AppointmentId = appointmentId;
            RoomId = roomId;
            StartHour = startHour;
            Length = length;
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public int AppointmentId { get; private set; }
        public int RoomId { get; private set; }
        public int StartHour { get; private set; }
        public int Length { get; private set; }
        public string UserName { get; private set; }
    }
}
