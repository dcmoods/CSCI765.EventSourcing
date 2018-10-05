using Appointment.QueryStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Web.Site.ViewModels
{
    public class IndexViewModel : ViewModelBase
    {
        public IList<RoomSchedule> RoomSchedules { get; set; }
    }
}
