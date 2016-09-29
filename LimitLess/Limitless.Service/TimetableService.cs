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
    public interface ITimetableService
    {
        //IEnumerable<Timetable> GetCategories(string name = null);
        Timetable GetTimetable(int id);
       // Timetable GetTimetable(string name);
        void CreateTimetable(Timetable Timetable);
        void SaveTimetable();
    }
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository TimetablesRepository;
        private readonly IUnitOfWork unitOfWork;

        public TimetableService(ITimetableRepository TimetablesRepository, IUnitOfWork unitOfWork)
        {
            this.TimetablesRepository = TimetablesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ITimetableService Members

        //public IEnumerable<Timetable> GetCategories(string name = null)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return TimetablesRepository.GetAll();
        //    else
        //        return TimetablesRepository.GetAll().Where(c => c.name == name);
        //}

        public Timetable GetTimetable(int id)
        {
            var Timetable = TimetablesRepository.GetById(id);
            return Timetable;
        }

        //public Timetable GetTimetable(string name)
        //{
        //    var Timetable = TimetablesRepository.GetTimetableByName(name);
        //    return Timetable;
        //}

        public void CreateTimetable(Timetable Timetable)
        {
            TimetablesRepository.Add(Timetable);
        }

        public void SaveTimetable()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}