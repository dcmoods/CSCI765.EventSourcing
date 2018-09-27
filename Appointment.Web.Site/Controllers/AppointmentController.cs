using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appointment.Web.Site.Application;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Web.Site.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentService _service = new AppointmentService();

        [HttpPost]
        public IActionResult Add(int roomId, int startHour, int length, string name, string notes)
        {
            _service.AddAppointment(roomId, startHour, length, name, notes);
            return RedirectToAction("index", "home");
        }
    }
}