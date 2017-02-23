using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limitless.Model

{
    public class Hall
    {
        [Key]
        public int hallId { get; set; }
        public string name { get; set; }
        public int maxCapacity { get; set; }
        public string userId { get; set;}
        
    }
}
