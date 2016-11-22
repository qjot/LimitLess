using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    public class TableInfo
    {
        public int Page { get; set; }
        public string SearchQuery { get; set; }
        public int PerPage { get; set; }
        public string Order { get; set; }
        public string OrderDirection { get; set; }
    }
}
