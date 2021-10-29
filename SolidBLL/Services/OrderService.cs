using System;
using System.Collections.Generic;
using System.Linq;
using SolidDAL.Entities;
using SolidDAL.UoW;

namespace SolidBLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        IEnumerable<Order> GetOrderListByUserId(Guid userid)
        {
            var user = _unitOfWork.UserRepository.GetById(userid);
            var orders = _unitOfWork.OrderRepository.GetAllByFilter(order => order.Client.Equals(user));
            return orders;
        }

        Dictionary<User, IEnumerable<Order>> GetAllUserOrdersDictionary()
        {
            var allOrders = _unitOfWork.OrderRepository.GetAllByFilter(x => true);
            return allOrders.GroupBy(x => x.Client).ToDictionary(grouping=>grouping.Key, grouping=>grouping.Select(x=>x));
        }

        public void CreateOrder(Order newOrder)
        {
            _unitOfWork.OrderRepository.Create(newOrder);
        }

        public IEnumerable<Order> GetAllOrdersByUser(User user)
        {
            return _unitOfWork.OrderRepository.GetAllByFilter(order => order.Client.Equals(user));
        }
    }
}