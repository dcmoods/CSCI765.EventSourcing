using Appointment.CommandStack.Commands;
using Appointment.CommandStack.Domain.Services;
using Appointment.QueryStack.Data;
using Appointment.QueryStack.Model;
using CSCI765EventSourcing.SharedKernel;
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

        public void EditAppointment(int appointmentId, int roomId, int startHour, int length, string name)
        {
            var command = new EditAppointmentCommand(appointmentId, roomId, startHour, length, name);
            Program.Bus.Send(command);
        }
        #endregion

        #region Query stack endpoints
        public Slot GetAppointment(int id)
        {
            var db = new Database();
            var Appointment = (from a in db.Appointments where a.Id == id select a).FirstOrDefault();
            if (Appointment != null)
            {
                var slot = new Slot { AppointmentId = Appointment.Id, RoomId = Appointment.RoomId, Name = Appointment.Name, Length = Appointment.Length, StartingAt = Appointment.StartingAt };
                return slot;
            }
            return new Slot();
        }

        public SlotHistory History(int id)
        {
            var history = new HistoryService().GetHistory(id);
            return history;
        }
        #endregion
    }
}
