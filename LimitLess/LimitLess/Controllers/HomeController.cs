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

        //public ActionResult Index()
        //{
        //    IEnumerable<Hall> halls;
        //    IEnumerable<Hall> Events;
        //    Event newEvent = new Event
        //    {
        //        capacity = 20,
        //        classesId = 0,
        //        //date = DateTime.Now,
        //        hallId = 1,
        //        EventID = 1,
        //        trainerID = 1

        //    };

        //    Hall newHall = new Hall
        //    {   
        //        maxCapacity = 20,
        //        name = "Sala 1",
        //        hallId = 0
        //    };
        //    hallService.CreateHall(newHall);
        //    hallService.SaveHall();
        //    halls = hallService.GetHalls();


        //    EventService.CreateEvent(newEvent);
        //    EventService.SaveEvent();



        //    ViewBag.Message = halls.FirstOrDefault().name;
        //    return View();
        //}

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