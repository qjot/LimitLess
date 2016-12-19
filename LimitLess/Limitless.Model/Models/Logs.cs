using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Limitless.Model
{
    [XmlRoot("LogEntry")]
    public class Logs
    {
        [Key]
        public int logId{ get; set; }
        [XmlElement("Thread")]
        public string Thread { get; set; }
        [XmlElement("Level")]
        public string Level { get; set; }
        [XmlElement("Logger")]
        public string Logger { get; set; }
        [XmlElement("Message")]
        public string Message { get; set; }
        [XmlElement("Exception")]
        public bool Exception { get; set; }
        [XmlElement("Date")]
        public DateTime Date { get; set; }
        [XmlElement("userID")]
        public string userID { get; set; }
        [XmlElement("Identity")]
        public string userName { get; set; }
        [XmlElement("additionalInfo")]
        public string additionalInfo { get; set; }
    }
}
