using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class OrderService : IOrderService
    {

        private readonly ApplicationDbContext _context;
        


        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<int> CreateDetails(OrderDetail orderDetail)
        {
            await _context.orderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();

            return orderDetail.Id;
        }

        public async Task CreateOrder(Order order)
        {
           await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(OrderDetail orderDetail)
        {
            _context.orderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDetail> GetById(int id)
        {
            return await _context.orderDetails.SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrderItems(int orderDetailId)
        {
            return await _context.orders.Where(o => o.OrderDetailId == orderDetailId).ToListAsync();
        }

        public async Task DecreaseStock(int productId, int quantity)
        {
            var product = await _context.products.SingleOrDefaultAsync(p => p.Id == productId);
            var stock = await _context.stocks.SingleOrDefaultAsync(s => s.Id == product.stockId);

            stock.Quantity -= quantity;
            _context.stocks.Update(stock);
            await _context.SaveChangesAsync();

        }

        public async Task IncreaseStock(int productId, int quantity)
        {
            var product = await _context.products.SingleOrDefaultAsync(p => p.Id == productId);
            var stock = await _context.stocks.SingleOrDefaultAsync(s => s.Id == product.stockId);

            stock.Quantity += quantity;
            _context.stocks.Update(stock);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<OrderDetail>> MyOrders(string userId)
        {
            return await _context.orderDetails.Where(o => o.UserId == userId).ToListAsync();
        }

        


        
    }
}