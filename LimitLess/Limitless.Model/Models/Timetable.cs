using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    public class Timetable
    {
        public int timetableID { get; set; }
        public DateTime? date { get; set; }
        public int capacity { get; set; }

        public virtual List<User> usersList { get; set; }
        public int classesID { get; set; }
        public int hallID { get; set; }
        public int trainerID{ get; set; }
    }
}
