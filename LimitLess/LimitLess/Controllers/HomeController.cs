using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Limitless.Data;
using Limitless.Data.Infrastructure;
using Limitless.Model;
using Limitless.Service;

namespace Limitless.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHallService hallService;
        private readonly IEventService EventService;

        public HomeController(IHallService hallService, IEventService EventService)
        {
            this.hallService = hallService;
            this.EventService = EventService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your about page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}