using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limitless.Model
{
    public class Event
    {
        [Key]
        public int eventId { get; set; }
        //public DateTime? date { get; set; }
        public int capacity { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public DateTime date { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; }
        public int? classesTypeId { get; set; }
        [ForeignKey("classesTypeId")]
        public virtual ClassesType classesType { get; set; }

        public int hallId { get; set; }
        [ForeignKey("hallId")]
        public virtual Hall hall { get; set; }

        public string trainerId { get; set; }
        [ForeignKey("trainerId")]
        public virtual User trainer { get; set; }

        public virtual ICollection<User> members { get; set; }
    }
}
