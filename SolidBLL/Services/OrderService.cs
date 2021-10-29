using System.Collections.Generic;
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

        public void CreateOrder(Order newOrder)
        {
            _unitOfWork.OrderRepository.Create(newOrder);
        }

        public IEnumerable<Order> GetAllOrdersByUser(User user)
        {
            return _unitOfWork.OrderRepository.GetAllByFilter(order => order.Client.Equals(user));
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
        }
    }
}