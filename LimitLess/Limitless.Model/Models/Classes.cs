using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Limitless.Model
{
    public class Classes
    {
        public int id { get; set; }
        public string  last { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool allDay { get; set; }
        public int maxCapacity { get; set; }


        public int classesTypeId { get; set; }
        [Key]
        [ForeignKey("classesTypeId")]
        public virtual ClassesType ClassesType { get; set; }

        
    }
}
