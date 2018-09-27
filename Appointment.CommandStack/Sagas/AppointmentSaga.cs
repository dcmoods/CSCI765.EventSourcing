using Appointment.CommandStack.Commands;
using Appointment.CommandStack.Events;
using Appointment.Domain.Model;
using Appointment.Infrastructure.Framework;
using Appointment.Infrastructure.Framework.EventStore;
using Appointment.Infrastructure.Framework.Repositories;
using Appointment.Infrastructure.Persistence.SqlServer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.CommandStack.Sagas
{
    public class AppointmentSaga : Saga,
        IStartWithMessage<RequestAppointmentCommand>
    {
        private readonly IRepository _repository;

        public AppointmentSaga(IBus bus, IEventStore eventStore) 
            : base(bus, eventStore)
        {
            _repository = new AppointmentRepository();
        }

        public AppointmentSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore)
        {
            _repository = repository;
        }

        public void Handle(RequestAppointmentCommand message)
        {
            var request = AppointmentRequest.Factory.Create(message.RoomId, message.StartHour, 
                message.Length, message.UserName, message.Notes);

            var response = _repository.CreateAppointmentFromRequest(request);
            if (!response.Success)
            {
                var rejected = new AppointmentRejectedEvent(request.Id, response.Description);
                Bus.RaiseEvent(rejected);
                return;
            }

            var slotInfo = request.ToSlotInfo();
            var created = new AppointmentCreatedEvent(request.Id, response.AggregateId, slotInfo);
            Bus.RaiseEvent(created);
        }
    }
}
