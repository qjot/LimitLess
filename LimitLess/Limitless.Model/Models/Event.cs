using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limitless.Model
{
    public class Event
    {
        public int eventId { get; set; }
        //public DateTime? date { get; set; }
        public int capacity { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        //  public virtual List<User> usersList { get; set; }
        public int classesId { get; set; }
        [Key]
        [ForeignKey("classesId")]
        public virtual Classes classes { get; set; }

        public int hallId { get; set; }
        [Key]
        [ForeignKey("hallId")]
        public virtual Hall hall { get; set; }

        public string trainerId { get; set; }
        [Key]
        [ForeignKey("trainerId")]
        public virtual ApplicationUser trainer { get; set; }

        public virtual ICollection<ApplicationUser> members { get; set; }
    }
}
