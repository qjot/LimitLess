﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Limitless.Model
{
    public class User : IdentityUser
    {
        [DisplayName("Name")]
       private string name { get; set; }
        [DisplayName("Birthday")]
        public DateTime? birthday { get; set; }
        [DisplayName("Join Date")]
        public DateTime? joinDate { get; set; }
        [DisplayName("Renewal Date")]
        public DateTime? renewalDate { get; set; }
        [DisplayName("Last Payment")]
        public DateTime? lastPayment { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public int? membershipId { get; set; }
        [Key]
        [ForeignKey("membershipId")]
        public virtual Membership membership { get; set; }


    }
}
