using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Web.Site.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Title = "CSCI 765 ES Project";
        }

        public string Title { get; set; }
    }
}
