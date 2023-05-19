using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll(int categoryId = 0)
        {
            if(categoryId == 0)
            {
                return await _context.products.ToListAsync();
            }

            return await _context.products.Where(p => p.categoryId == categoryId).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> IsValidCategory(int id)
        {
            return await _context.categories.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> IsValidOffer(int id)
        {
            return await _context.offers.AnyAsync(o => o.Id == id);
        }

        public async Task<bool> IsValidStock(int id)
        {
           return await _context.stocks.AnyAsync(s => s.Id == id);
        }

        public async Task Upadte(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}