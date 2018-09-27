using Appointment.Infrastructure.EventStore.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appointment.Infrastructure.EventStore.SqlServer.Repository
{
    public class EventRepository
    {
        private readonly CQRSEventStore _db = new CQRSEventStore();

        public void Store(LoggedEvent eventToLog)
        {
            eventToLog.TimeStamp = DateTime.Now;
            _db.LoggedEvent.Add(eventToLog);
            _db.SaveChanges();
        }

        public IList<LoggedEvent> All(int aggregateId)
        {
            var events = (from e in _db.LoggedEvent where e.AggregateId == aggregateId select e).ToList();
            return events;
        }
    }
}
