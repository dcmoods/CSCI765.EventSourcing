using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Appointment.Web.Site.Models;
using Appointment.Web.Site.Application;

namespace Appointment.Web.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController()
        {
            _homeService = new HomeService();
        }

        public IActionResult Index()
        {
            var model = _homeService.GetIndexViewModel();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
