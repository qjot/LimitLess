﻿using System;
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
    [RequireHttps]
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
            IndexViewModel model = new IndexViewModel();
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