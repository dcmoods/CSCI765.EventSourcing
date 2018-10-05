using Appointment.Domain.Common;
using Appointment.Domain.Model;
using Appointment.Infrastructure.Framework;
using Appointment.Infrastructure.Framework.Repositories;
using Appointment.Infrastructure.Persistence.SqlServer.Data;
using Appointment.Infrastructure.Persistence.SqlServer.Repository.Adapters;
using System;
using System.Linq;

namespace Appointment.Infrastructure.Persistence.SqlServer.Repository
{
    public class AppointmentRepository : IRepository
    {
        private readonly PersistenceStore _persistenceStore;

        public AppointmentRepository()
        {
            _persistenceStore = new PersistenceStore();
        }

        public T GetById<T>(int id) where T : IAggregate
        {
            throw new NotImplementedException();
        }


        public CommandResponse CreateAppointmentFromRequest<T>(T item) where T : class, IAggregate
        {
            var request = item as AppointmentRequest;
            var appointment = Adapter.RequestToAppointment(request);

            _persistenceStore.Appointments.Add(appointment);
            var count = _persistenceStore.SaveChanges();

            var response = new CommandResponse(count > 0, appointment.Id) { RequestId = new Guid(appointment.RequestId) };
            return response;
        }

        public CommandResponse Update(int appointmentId, int roomId, int hour, int length, string name)
        {
            var appointment = (from a in _persistenceStore.Appointments where a.Id == appointmentId select a).FirstOrDefault();
            if (appointment == null)
                return CommandResponse.Fail;

            appointment.Id = appointmentId;
            appointment.RoomId = roomId;
            appointment.StartingAt = hour;
            appointment.Length = length;
            appointment.Name = name;
            var count = _persistenceStore.SaveChanges();
            var response = new CommandResponse(count > 0, appointment.Id);
            return response;
        }
    }
}
