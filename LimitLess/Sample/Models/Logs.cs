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
    
    public partial class Logs
    {
        public int logId { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public bool Exception { get; set; }
        public System.DateTime Date { get; set; }
        public string userID { get; set; }
        public string userName { get; set; }
        public string additionalInfo { get; set; }
    
        public virtual Users User { get; set; }
    }
}
