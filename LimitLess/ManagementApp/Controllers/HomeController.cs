using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Limitless.Model;
using Limitless.Service;
using ManagementApp.DataAnnotation;
using ManagementApp.Models;

namespace ManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHallService hallService;
        private readonly ITimetableService timetableService;

        public HomeController(IHallService hallService, ITimetableService timetableService)
        {
            this.hallService = hallService;
            this.timetableService = timetableService;
        }

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            //model.entityNamesDictionary
            return View();
        }


        [CustomAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}