using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Data.Repositories;
using Limitless.Model;

namespace Limitless.Service
{
    public interface ILogService
    {
        IEnumerable<Logs> GetLogs(string name = null);
        Logs GetLog(int id);
        // Logs GetLog(string name);
        void CreateLog(Logs logs);
        void SaveLog();
        void UpdateLog(Logs logs);
        bool DeleteLog(Logs logs);
    }
    public class LogService : ILogService
    {
        private readonly ILogsRepository LogsRepository;
        private readonly IUnitOfWork unitOfWork;

        public LogService(ILogsRepository LogsRepository, IUnitOfWork unitOfWork)
        {
            this.LogsRepository = LogsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ILogService Members

        public IEnumerable<Logs> GetLogs(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return LogsRepository.GetAll();
            else
                return LogsRepository.GetAll();
        }

        public Logs GetLog(int id)
        {
            var Log = LogsRepository.GetById(id);
            return Log;
        }

        //public Logs GetLog(string name)
        //{
        //    var Logs = LogsRepository.GetLogByName(name);
        //    return Logs;
        //}

        public void CreateLog(Logs logs)
        {
            LogsRepository.Add(logs);
            unitOfWork.Commit();
        }

        public void SaveLog()
        {
            unitOfWork.Commit();
        }

        public void UpdateLog(Logs logs)
        {
            LogsRepository.Update(logs);
            unitOfWork.Commit();
        }

        public bool DeleteLog(Logs logsToDelete)
        {
            try
            {
                LogsRepository.Delete(logsToDelete);
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}