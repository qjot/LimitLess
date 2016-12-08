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
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(string name = null);
        Event GetEvent(int id);
       // Event GetEvent(string name);
        void CreateEvent(Event Event);
        void SaveEvent();
        void UpdateEvent(Event Event);
        bool DeleteEvent(Event Event);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepository EventsRepository;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IEventRepository EventsRepository, IUnitOfWork unitOfWork)
        {
            this.EventsRepository = EventsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IEventService Members

        public IEnumerable<Event> GetEvents(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return EventsRepository.GetAll();
            else
                return EventsRepository.GetAll();
        }

        public Event GetEvent(int id)
        {
            var Event = EventsRepository.GetById(id);
            return Event;
        }

        //public Event GetEvent(string name)
        //{
        //    var Event = EventsRepository.GetEventByName(name);
        //    return Event;
        //}

        public void CreateEvent(Event Event)
        {
            EventsRepository.Add(Event);
            unitOfWork.Commit();
        }

        public void SaveEvent()
        {
            unitOfWork.Commit();
        }

        public void UpdateEvent(Event Event)
        {
            EventsRepository.Update(Event);
            unitOfWork.Commit();
        }

        public bool DeleteEvent(Event eventToDelete)
        {
            try
            {
                EventsRepository.Delete(eventToDelete);
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