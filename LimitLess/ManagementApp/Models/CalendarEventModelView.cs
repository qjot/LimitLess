using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models
{
    public class CalendarEventModelView
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; }
    }
}