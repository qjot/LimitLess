using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models
{
    public class EventViewModel
    {
        public Dictionary<string, string> trainerDictionary { get; set; }
        public Dictionary<int, string> classesTypeDictionary { get; set; }
        public Dictionary<int, string> hallDictionary { get; set; }
    }

    public class CalendarEventModelView
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string date { get; set; }
        public bool allDay { get; set; }
        public int capacity { get; set; }
        public int usersQuantity { get; set; }
        public string hallName { get; set; }
        public string trainerName { get; set; }
    }

    public class UpdateEventModelView
    {
        public string title { get; set; }
        public string newEventDate { get; set; }
        public string newEventTime{ get; set; }
        public string newEventDuration { get; set; }
        public string trainerId { get; set; }
        public int classesTypeId { get; set; }
        public int hallId { get; set; }
    }

}