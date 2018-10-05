using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appointment.Web.Site.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Web.Site.Controllers
{
    
    public class ApiController : Controller
    {
        private readonly AppointmentService _service = new AppointmentService();

        [HttpGet]
        public JsonResult Scheduling(int id)
        {
            var booking = _service.GetAppointment(id);
            return Json(booking);
        }

        [HttpGet]
        public JsonResult SchedulingHistory(int id)
        {
            var history = _service.History(id);
            var dto = history.ToJavaScriptSlotHistory();
            return Json(dto);
        }
    }
}