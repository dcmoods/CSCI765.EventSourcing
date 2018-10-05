using System.Linq;
using Appointment.Infrastructure.Persistence.SqlServer.Data;
using Persistence = Appointment.Infrastructure.Persistence.SqlServer.Data;

namespace Appointment.QueryStack.Data
{
    public class Database : IDatabase
    {
        private readonly PersistenceStore _persistenceStore;

        public Database()
        {
            _persistenceStore = new PersistenceStore();
        }

        public IQueryable<Persistence.Appointment> Appointments
        {
            get
            {
                return _persistenceStore.Appointments;
            }
        }

        public IQueryable<Room> Rooms
        {
            get
            {
                return _persistenceStore.Rooms;
            }
        }
    }
}
