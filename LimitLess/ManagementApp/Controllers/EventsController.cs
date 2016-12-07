using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Limitless.Data;
using Limitless.Model;
using Limitless.Service;
using ManagementApp.Models;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace ManagementApp.Controllers
{
    public class EventsController : Controller
    {

        private readonly IHallService hallService;
        private readonly IEventService eventService;
        private readonly IClassesService classesSerice;
        private ApplicationUserManager _userManager;

        public EventsController(IHallService hallService, IEventService eventService,
                                IClassesService classesSerice)
        {
            //UserManager = userManager;
            this.hallService = hallService;
            this.eventService = eventService;
            this.classesSerice = classesSerice;

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
            IEnumerable<Event> eventList = new List<Event>();

            //Event newEvent = new Event
            //{
            //    eventId = 1,
            //    classesTypeId = 1,
            //    hallId= 1,
            //    start = DateTime.Now.AddDays(2),
            //    end= DateTime.Now.AddDays(3),
            //    date = DateTime.Now,
            //    capacity= 20,
            //    trainerId = "172ef3fd-127f-407d-9b13-129dc6a0333d",
            //};
            //eventService.CreateEvent(newEvent);
            //eventService.SaveEvent();
            //eventList.Add(newEvent);
            eventList = eventService.GetEvents();
            List<CalendarEventModelView> calendarEvenList = new List<CalendarEventModelView>();
            parseDatabaseEventToModelView(eventList, calendarEvenList);
            return View(eventService.GetEvents());
        }

        public JsonResult GetEvents(string start, string end)
        {
            IEnumerable<Event> eventList = new List<Event>();
            eventList = eventService.GetEvents();
            List<CalendarEventModelView> calendarEvenList = new List<CalendarEventModelView>();
            parseDatabaseEventToModelView(eventList, calendarEvenList);
       
            var rows = calendarEvenList.ToArray();
            JsonConvert.SerializeObject(calendarEvenList, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public void UpdateEvent(int id, string NewEventStart, string NewEventEnd)
        {
            Event oldEvent = eventService.GetEvent(id);
            DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
            DateTime DateTimeEnd = DateTime.Parse(NewEventEnd, null, DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
            oldEvent.start = DateTimeStart;
            oldEvent.end = DateTimeEnd;
            eventService.UpdateEvent(oldEvent);
        }

        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            var date = DateTime.ParseExact(NewEventDate + " " + NewEventTime, "dd/MM/yyyy HH:mm",
                CultureInfo.InvariantCulture);
            try
            {
                Event newEvent = new Event
                {
                    start = date,
                    trainerId = "172ef3fd-127f-407d-9b13-129dc6a0333d",
                    classesTypeId = 1,
                    hallId = 1,
                    end = date.AddHours(1.0),
                };
                eventService.CreateEvent(newEvent);
                
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        private void parseDatabaseEventToModelView(IEnumerable<Event> eventList, List<CalendarEventModelView> calendarEvenList)
        {
            foreach (var item in eventList)
            {
                ClassesType currentClasses = classesSerice.GetClasses(item.classesTypeId.GetValueOrDefault());
                calendarEvenList.Add(new CalendarEventModelView
                {
                    id = item.eventId,
                    start = item.start.ToString("s"),
                    end = item.end.ToString("s"),
                    description = currentClasses.description,
                    allDay = item.allDay,
                    capacity = item.capacity,
                    date = item.date.ToString("s"),
                    title = currentClasses.name
                });
            }
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
            Event @event = eventService.GetEvent(id);
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
            Event @event = eventService.GetEvent(id);
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
            Event @event = eventService.GetEvent(id);
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
            Event @event = eventService.GetEvent(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }
    }
}
