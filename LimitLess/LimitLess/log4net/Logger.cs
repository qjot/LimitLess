
using System;
using Limitless.Data.Logger;
using log4net;

namespace LimitLess.Web.log4net
{
    public class Logger :ILogger
    {
        private static ILog _log = LogManager.GetLogger("ErrorLogger");

        public void Info(object msg)
        {
            _log.Info(msg);
        }

        public void Error(Exception ex)
        {
            _log.Error(ex.Message);
        }

        public void Debug(string msg)
        {
            _log.Debug(msg);
        }

        public void Error(string msg, Exception ex)
        {
            _log.Error(msg, ex);
        }
    }
}