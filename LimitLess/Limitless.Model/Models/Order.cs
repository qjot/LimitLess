using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    public class Order
    {
        public int orderId { get; set; }
       // public DateTime? orderDate { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        //TODO NUGET DATAANNOTATION [EmailAddress]
        public string email { get; set; }
        public decimal? total { get; set; }
        public string nip { get; set; }
    }
}
