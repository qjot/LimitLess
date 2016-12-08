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
using Microsoft.AspNet.Identity;
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
            
            Dictionary<string, string> trainers = new Dictionary<string, string>();
            Dictionary<int, string> classes = new Dictionary<int, string>();
            Dictionary<int, string> halls = new Dictionary<int, string>();
            foreach (var item in classesSerice.GetClasses())
            {
                classes.Add(item.classesTypeId, item.name);
            }
            foreach (var item in hallService.GetHalls())
            {
                halls.Add(item.hallId, item.name);
            }
            foreach (var item in UserManager.Users)
            {
                trainers.Add(item.Id, item.UserName);
            }
            EventViewModel avialableDataForNewEvent = new EventViewModel
            {
                trainerDictionary = trainers,
                classesTypeDictionary = classes,
                hallDictionary = halls
            };
            return View(avialableDataForNewEvent);
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
            DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, DateTimeStyles.RoundtripKind); // and convert offset to localtime
            DateTime DateTimeEnd = DateTime.Parse(NewEventEnd, null, DateTimeStyles.RoundtripKind); // and convert offset to localtime
            oldEvent.start = DateTimeStart;
            oldEvent.end = DateTimeEnd;
            eventService.UpdateEvent(oldEvent);
        }

        public bool SaveEvent(UpdateEventModelView newEventMV)
        {
            string eventDate = newEventMV.newEventDate + " " + newEventMV.newEventTime;
            var date = DateTime.Parse(eventDate, null, DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
            //try
            //{
                double addHours;
            if (Double.TryParse(newEventMV.newEventDuration, out addHours))
            {
                return false;
            }
                Event newEvent = new Event
                {
                    date = DateTime.Now,
                    start = date,
                    trainerId = newEventMV.trainerId,
                    classesTypeId = newEventMV.classesTypeId,
                    hallId = newEventMV.hallId,
                    end = date.AddHours(addHours/60),
                };
                eventService.CreateEvent(newEvent);
    //    }
    //        catch (Exception e)
    //        {
                
    //            return false;
    //}
            return true;

        }

        private void parseDatabaseEventToModelView(IEnumerable<Event> eventList, List<CalendarEventModelView> calendarEvenList)
        {
            
            foreach (var item in eventList)
            {
                User trainer = UserManager.FindById(item.trainerId);
                //item.trainer = trainer;
                //eventService.UpdateEvent(item);
                //ICollection<User> kolekcja = new List<User>();
                //kolekcja.Add(trainer);
                //item.members = kolekcja;
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
                    title = currentClasses.name,
                    hallName = item.hall.name,
                    trainerName = trainer.UserName,
                    usersQuantity = 1
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
