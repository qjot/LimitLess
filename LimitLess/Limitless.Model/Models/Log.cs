using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    public class Log
    {
        public int idLog { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public bool Exception { get; set; }
        public DateTime Date { get; set; }

    }
}
