using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Limitless.Model
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        // public DateTime? orderDate { get; set; }
        [DisplayFormat(DataFormatString = "dd-MM-yyyy hh:mm")]
        public DateTime? OrderDate { get; set; }
        public string userId { get; set; }
        [Key]
        [ForeignKey("userId")]
        public virtual User user { get; set; }
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
        public virtual ICollection<OrderDetail> orderDetails { get; set; }

    }
}
