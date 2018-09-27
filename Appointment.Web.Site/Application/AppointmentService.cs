using Appointment.CommandStack.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Web.Site.Application
{
    public class AppointmentService
    {
        #region Command Stack endpoints
        public void AddAppointment(int roomId, int startHour, int length, string name, string notes)
        {
            var command = new RequestAppointmentCommand(roomId, startHour, length, name, notes);
            Program.Bus.Send(command);
        }

        #endregion
    }
}
