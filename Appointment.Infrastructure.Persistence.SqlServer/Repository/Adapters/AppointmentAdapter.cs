using Appointment.Domain.Model;

namespace Appointment.Infrastructure.Persistence.SqlServer.Repository.Adapters
{
    public class Adapter
    {
        public static Data.Appointment RequestToAppointment(AppointmentRequest entity)
        {
            var appointment = new Data.Appointment
            {
                RoomId = entity.RoomId,
                Length = entity.Length,
                Name = entity.Name,
                StartingAt = entity.StartHour,
                RequestId = entity.Id.ToString()
            };
            return appointment;

        }
    }
}
