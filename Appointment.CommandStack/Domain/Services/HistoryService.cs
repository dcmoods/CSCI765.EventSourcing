using Appointment.CommandStack.Events;
using Appointment.Infrastructure.EventStore.SqlServer.Repository;
using CSCI765EventSourcing.SharedKernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.CommandStack.Domain.Services
{
    public class HistoryService
    {
        public SlotHistory GetHistory(int aggregateId)
        {
            //var serializer = Newtonsoft.Json;
            var history = new SlotHistory { AppointmentId = aggregateId };

            var events = new EventRepository().All(aggregateId);
            foreach (var e in events)
            {
                var slot = new SlotInfo();
                switch (e.Action)
                {
                    case "AppointmentCreatedEvent":
                        var createdEvent = JsonConvert.DeserializeObject<AppointmentCreatedEvent>(e.Cargo);
                        slot = createdEvent.Data;
                        slot.Action = "Created";
                        slot.When = createdEvent.When.ToLocalTime(); ;
                        slot.RoomId = createdEvent.Id;
                        break;
                    //case "BookingUpdatedEvent":
                    //    var updatedEvent = serializer.Deserialize<BookingUpdatedEvent>(e.Cargo);
                    //    slot = updatedEvent.Data;
                    //    slot.Action = "Updated";
                    //    slot.When = updatedEvent.When.ToLocalTime();
                    //    slot.BookingId = updatedEvent.Id;
                    //    break;
                }

                history.ChangeList.Add(slot);
            }
            return history;
        }
    }
}
