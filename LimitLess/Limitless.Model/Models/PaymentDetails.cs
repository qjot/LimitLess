using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    public class PaymentDetails
    {
        public int paymentDetailsId {get; set; }
        public int orderId { get; set; }
        public int paymentDataId { get; set; }
        [DisplayFormat(DataFormatString = "dd-MM-yyyy hh:mm")]
        public DateTime? paymentDate { get; set; }
        public decimal value { get; set; }
        [Key]
        [ForeignKey("orderId")]
        public virtual ICollection<Order> order { get; set; }
        [Key]
        [ForeignKey("paymentDataId")]
        public virtual PaymentData paymentData { get; set; }

    }
}
