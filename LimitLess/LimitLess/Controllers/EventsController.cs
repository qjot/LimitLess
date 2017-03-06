using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Limitless.Data;
using Limitless.Model;
using Limitless.Service;
using Limitless.Web;
using Limtless.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Limitless.log4net;

namespace LimitLess.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IHallService hallService;
        private readonly IEventService eventService;
        private readonly IClassesService classesSerice;
        private ApplicationUserManager _userManager;
        private readonly ILogger _logger;

        public EventsController(IHallService hallService, IEventService eventService,
                                IClassesService classesSerice, ILogger logger)
        {
            //UserManager = userManager;
            this.hallService = hallService;
            this.eventService = eventService;
            this.classesSerice = classesSerice;
            this._logger = logger;

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
            _logger.Info(string.Format("user: {0} action: Index view: Events", User.Identity.Name));
            return View();
        }

        public JsonResult GetEvents(string start, string end)
        {
            _logger.Info(string.Format("user: {0} action: LoadEvents view: Events", User.Identity.Name));

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

        private void parseDatabaseEventToModelView(IEnumerable<Event> eventList, List<CalendarEventModelView> calendarEvenList)
        {

            foreach (var item in eventList)
            {
                User trainer = UserManager.FindById(item.trainerId);
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



    }
}
