using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext _context;

        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<Stock> Create(Stock stock)
        {
            await _context.stocks.AddAsync(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task Delete(Stock stock)
        {
              _context.stocks.Remove(stock);
           await  _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Stock>> getall()
        {
            return await _context.stocks.ToListAsync();
        }

        public async Task<Stock> GetbyId(int stockId)
        {
            return await _context.stocks.SingleOrDefaultAsync(s => s.Id == stockId);
        }

        public async Task Update(Stock stock)
        {
            _context.stocks.Update(stock);
            await _context.SaveChangesAsync();
        }
    }
}