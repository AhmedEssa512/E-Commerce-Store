using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface IOrderService
    {
        Task<int> CreateDetails(OrderDetail orderDetail);
        Task CreateOrder(Order order);
        Task<IEnumerable<OrderDetail>> MyOrders(string userId);
        Task<IEnumerable<Order>> GetOrderItems(int orderDetailId);
        Task Delete(OrderDetail orderDetail);
        Task<OrderDetail> GetById(int id);
        Task DecreaseStock(int productId,int quantity);
        Task IncreaseStock(int productId, int quantity);

        



    }
}