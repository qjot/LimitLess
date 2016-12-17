using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using log4net.Core;
using log4net.Layout;

namespace LimitLess.Web.log4net
{
    public class MyXmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            writer.WriteStartElement("LogEntry");
            writer.WriteStartElement("Date");
            writer.WriteString(loggingEvent.TimeStamp.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Message");
            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();
            writer.WriteStartElement("User");
            writer.WriteString(loggingEvent.Identity);
            writer.WriteEndElement();
            writer.WriteStartElement("Level");
            writer.WriteString(loggingEvent.Level.Name);
            writer.WriteEndElement();
            writer.WriteStartElement("Thread");
            writer.WriteString(loggingEvent.ThreadName);
            writer.WriteEndElement();
            writer.WriteStartElement("LoggerName");
            writer.WriteString(loggingEvent.LoggerName);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}