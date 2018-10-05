

using Appointment.Domain.Common;

namespace Appointment.Infrastructure.Framework.Repositories
{
    public interface IRepository
    {
        //TEntity Get(TKey id);
        //void Save(TEntity entity);
        //void Delete(TEntity entity);

        T GetById<T>(int id) where T : IAggregate;

        CommandResponse CreateAppointmentFromRequest<T>(T item) where T : class, IAggregate;
        CommandResponse Update(int appointmentId, int roomId, int hour, int length, string name);

    }
}