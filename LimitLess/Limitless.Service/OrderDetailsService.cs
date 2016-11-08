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

    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetOrderDetails(string name = null);
        OrderDetail GetOrderDetail(int id);
        void CreateOrderDetail(OrderDetail OrderDetail);
        void SaveOrderDetail();
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository OrderDetailRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderDetailService(IOrderDetailRepository OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.OrderDetailRepository = OrderDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IOrderDetailervice Members

        public IEnumerable<OrderDetail> GetOrderDetails(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return OrderDetailRepository.GetAll();
            else
                return OrderDetailRepository.GetAll().Where(c => c.name == name);
        }

        public OrderDetail GetOrderDetail(int id)
        {
            var OrderDetail = OrderDetailRepository.GetById(id);
            return OrderDetail;
        }


        public void CreateOrderDetail(OrderDetail OrderDetail)
        {
            OrderDetailRepository.Add(OrderDetail);
        }

        public void SaveOrderDetail()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}