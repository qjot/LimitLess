using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Limitless.Data;
using Limitless.Data.Infrastructure;
using Limitless.Model;
using Limitless.Service;
using Limitless.Data.Logger;

namespace Limitless.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHallService hallService;
        private readonly IEventService EventService;
        private readonly ILogger _logger;
        public HomeController(IHallService hallService, IEventService EventService,  ILogger logger)
        {
            this.hallService = hallService;
            this.EventService = EventService;
            this._logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Info(string.Format("user: {0} action: Index view: Home", User.Identity.Name));
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your about page.";
            return View();
        }

        public ActionResult Contact()
        {
            _logger.Info(string.Format("user: {0} action: Contact view: Home", User.Identity.Name));
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}