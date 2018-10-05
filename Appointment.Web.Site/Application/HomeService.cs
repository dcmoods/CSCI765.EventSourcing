using Appointment.Infrastructure.Persistence.SqlServer.Data;
using Appointment.QueryStack.Data;
using Appointment.QueryStack.Model;
using Appointment.Web.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Web.Site.Application
{
    public class HomeService
    {

        public IndexViewModel GetIndexViewModel()
        {
            var db = new Database();
            var roomSchedules = new List<RoomSchedule>();

            var rooms = db.Rooms.ToList();
            var roomIds = (from r in rooms select r.Id).Distinct().ToArray();
            var appointments = db.Appointments.Where(a => roomIds.Contains(a.RoomId));

            foreach (var room in rooms)
            {
                var schedule = GetScheduleForRoom(room, appointments.Where(a => a.RoomId == room.Id).ToList());
                roomSchedules.Add(schedule);
            }

            var viewModel = new IndexViewModel();
            viewModel.RoomSchedules = roomSchedules;
            return viewModel;
        }


        private static RoomSchedule GetScheduleForRoom(Room room, IList<Infrastructure.Persistence.SqlServer.Data.Appointment> appointments)
        {
            var schedule = new RoomSchedule();
            schedule.RoomId = room.Id;
            schedule.RoomName = room.Name;

            for (var hour = room.FirstSlot; hour <= room.LastSlot; hour++)
            {
                var slot = new Slot();
                slot.StartingAt = hour;

                var matchingAppointment = (from a in appointments where a.StartingAt == hour select a).FirstOrDefault();
                if (matchingAppointment != null)
                {
                    slot.AppointmentId = matchingAppointment.Id;
                    slot.Name = matchingAppointment.Name;
                    slot.Length = matchingAppointment.Length;
                    if (slot.Length > 1)
                        hour += (slot.Length - 1);
                }
                schedule.Slots.Add(slot);
            }
            return schedule;
        }
    }
}
