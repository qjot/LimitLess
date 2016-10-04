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
        private readonly ITimetableService timetableService;

        public HomeController(IHallService hallService, ITimetableService timetableService)
        {
            this.hallService = hallService;
            this.timetableService = timetableService;
        }

        public ActionResult Index()
        {
            IEnumerable<Hall> halls;
            IEnumerable<Hall> timetables;
            Timetable newTimetable = new Timetable
            {
                capacity = 20,
                classesID = 0,
                //date = DateTime.Now,
                hallID = 1,
                timetableID = 1,
                trainerID = 1

            };

            Hall newHall = new Hall
            {   
                maxCapacity = 20,
                name = "Sala 1",
                hallId = 0
            };
            hallService.CreateHall(newHall);
            hallService.SaveHall();
            halls = hallService.GetHalls();


            timetableService.CreateTimetable(newTimetable);
            timetableService.SaveTimetable();



            ViewBag.Message = halls.FirstOrDefault().name;
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