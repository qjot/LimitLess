using System.Collections.Generic;
using System.Linq;
using Limitless.Data.Infrastructure;
using Limitless.Data.Repositories;
using Limitless.Model;

namespace Limitless.Service
{

    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(string name = null);
        Order GetOrder(int id);
        void CreateOrder(Order Order);
        void SaveOrder();
    }
    public class Orderervice : IOrderService
    {
        private readonly IOrderRepository OrderRepository;
        private readonly IUnitOfWork unitOfWork;

        public Orderervice(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            this.OrderRepository = OrderRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IOrderervice Members

        public IEnumerable<Order> GetOrders(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return OrderRepository.GetAll();
            else
                return OrderRepository.GetAll().Where(c => c.username == name);
        }

        public Order GetOrder(int id)
        {
            var Order = OrderRepository.GetById(id);
            return Order;
        }

       
        public void CreateOrder(Order Order)
        {
            OrderRepository.Add(Order);
        }

        public void SaveOrder()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}