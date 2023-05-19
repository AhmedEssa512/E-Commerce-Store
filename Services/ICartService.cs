using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface ICartService
    {
        Task Create(Cart cart);
        Task Update(Cart cart);
        Task Delete(Cart cart);
         Task<Cart> GetUserCart(int id,string UserId);
        IEnumerable<Cart> Getall(string userId);
        Task<Cart> GetById(int cartId);
        // Task<int> TotalCost(string userId);

    }
}