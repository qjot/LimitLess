using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Limitless.Data;
using Limitless.Model;
using Limitless.Service;
using Microsoft.AspNet.Identity.Owin;

namespace ManagementApp.Controllers
{
    public class EventsController : Controller
    {

        private readonly IHallService hallService;
        private readonly IEventService EventService;
        private ApplicationUserManager _userManager;

        public EventsController(IHallService hallService, IEventService EventService)
        {
            //UserManager = userManager;
            this.hallService = hallService;
            this.EventService = EventService;

        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Events
        public ActionResult Index()
        {
            List<Event> eventList = new List<Event>();

            Event newEvent = new Event
            {
                eventId = 1,
                classesTypeId = 1,
                hallId= 1,
                start = DateTime.Now.AddDays(2),
                end= DateTime.Now.AddDays(3),
                capacity= 20,
                trainerId = "172ef3fd-127f-407d-9b13-129dc6a0333d"
            };
            
            EventService.CreateEvent(newEvent);
            EventService.SaveEvent();
            ViewBag.Message = hallService.GetHalls().FirstOrDefault().name;
            eventList.Add(newEvent);
            return View(EventService.GetEvents());
        }

        //public ActionResult GetEvents(double start, double end)
        //{
            
        //}

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = EventService.GetEvent(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventId,capacity,start,end,classesId,hallId,trainerId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }
            
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = EventService.GetEvent(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventId,capacity,start,end,classesId,hallId,trainerId")] Event @event)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = EventService.GetEvent(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = EventService.GetEvent(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }
    }
}
