using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class OfferService : IOfferService
    {

    private readonly ApplicationDbContext _context;

    public OfferService(ApplicationDbContext context)
    {
        _context = context;
    }


        public async Task Create(Offer offer)
        {
            await _context.offers.AddAsync(offer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Offer offer)
        {
            _context.offers.Remove(offer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Offer>> GetAll()
        {
            return await _context.offers.ToListAsync();
        }

        public async Task<Offer> GetById(int id)
        {
           return await _context.offers.SingleOrDefaultAsync(o => o.Id == id);
        }

        

        public async Task Update(Offer offer)
        {
            _context.offers.Update(offer);
            await _context.SaveChangesAsync();
        }
    }
}