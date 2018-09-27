using Appointment.Infrastructure.EventStore.SqlServer.Data;
using Appointment.Infrastructure.EventStore.SqlServer.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Appointment.Infrastructure.Framework.EventStore
{
    public class SqlEventStore : IEventStore
    {
        private static readonly EventRepository EventRepository = new EventRepository();

        public IEnumerable<Event> All(string matchId)
        {
            return null; //EventRepository.All(matchId);
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var loggedEvent = new LoggedEvent()
            {
                Action = theEvent.Name,
                AggregateId = theEvent.SagaId,
                Cargo = JsonConvert.SerializeObject(theEvent)
            };

            EventRepository.Store(loggedEvent);
        }

    }
}