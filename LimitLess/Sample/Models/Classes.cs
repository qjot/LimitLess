//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Classes
    {
        public int id { get; set; }
        public string last { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool allDay { get; set; }
        public int maxCapacity { get; set; }
        public int classesTypeId { get; set; }
    
        public virtual ClassesType ClassesType { get; set; }
    }
}
