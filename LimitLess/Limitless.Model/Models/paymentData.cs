using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    public class PaymentData
    {
        public int paymentDataId { get; set; }
        public int paymentTypeId { get; set; }
        public decimal value { get; set; }
        [Key]
        [ForeignKey("paymentTypeId")]
        public virtual PaymentType paymentType { get; set; }
    }
}
