using Limitless.Service;
using System.IO;
using System.Xml.Serialization;
using Limitless.log4net;
using Limitless.Model;
using System.Collections.Generic;
using System;

namespace Limitless.log4net
{
    public class LogDeserializer
    {
        private readonly ILogService logService;
        private string pathToLogXml;
        public LogsFromXml logs;

        public LogDeserializer(ILogService logService, string path)
        {
            logs = new LogsFromXml();
            this.logService = logService;
            logs.logList = new List<Logs>();
            pathToLogXml = path;
        }

        public bool Deserialize()
        {
            try
            {
                XmlSerializer desrializer = new XmlSerializer(typeof(Logs));
                StreamReader reader = new StreamReader(pathToLogXml);
                logs.logList = (List<Logs>)desrializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

            return true;
        }
        
    }
}
