using Limitless.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Data.Repositories;

namespace Limitless.Service
{

    public interface IHallService
    {
        IEnumerable<Hall> GetHalls(string name = null);
        Hall GetHall(int id);
        Hall GetHall(string name);
        void CreateHall(Hall Hall);
        void SaveHall();
    }
    public class HallService : IHallService
    {
        private readonly IHallRepository HallsRepository;
        private readonly IUnitOfWork unitOfWork;

        public HallService(IHallRepository HallsRepository, IUnitOfWork unitOfWork)
        {
            this.HallsRepository = HallsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IHallService Members

        public IEnumerable<Hall> GetHalls(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return HallsRepository.GetAll();
            else
                return HallsRepository.GetAll().Where(c => c.name == name);
        }

        public Hall GetHall(int id)
        {
            var Hall = HallsRepository.GetById(id);
            return Hall;
        }

        public Hall GetHall(string name)
        {
            var Hall = HallsRepository.GetHallByName(name);
            return Hall;
        }

        public void CreateHall(Hall Hall)
        {
            HallsRepository.Add(Hall);
        }

        public void SaveHall()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
