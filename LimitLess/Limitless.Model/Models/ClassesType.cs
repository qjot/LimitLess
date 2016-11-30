using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    [Table("ClassesType")]
    public class ClassesType
    {
        [Key]
        public int classesTypeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        

        public virtual ICollection<Event> events { get; set; }
    }
}
