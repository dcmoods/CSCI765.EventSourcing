using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence = Appointment.Infrastructure.Persistence.SqlServer.Data;

namespace Appointment.QueryStack.Data
{
    public interface IDatabase
    {
        IQueryable<Persistence.Appointment> Appointments { get; }
        IQueryable<Persistence.Room> Rooms { get; }
    }
}
