using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class CartService : ICartService
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;

        public CartService(ApplicationDbContext context,UserManager<IdentityUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        public async Task Create(Cart cart)
        {
            await _context.carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cart cart)
        {
            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public  IEnumerable<Cart> Getall(string userId)
        {
          return  _context.carts.Where(c => c.UserId == userId).ToList();
        }

        public async Task<Cart> GetById(int cartId)
        {
            return await _context.carts.SingleOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task<Cart> GetUserCart(int productId,string UserId)
        {
            return  await _context.carts.SingleOrDefaultAsync(c => c.ProductId == productId && c.UserId == UserId);
        }

        // public Task<int> TotalCost(string userId)
        // {
        //     var carts = Getall(userId);
        //     var total = 0;

        //     foreach (var item in carts)
        //     {
        //         total += item.
        //     }
        // }

        public async Task Update(Cart cart)
        {
            _context.carts.Update(cart);
            await _context.SaveChangesAsync();
        }
    }
}