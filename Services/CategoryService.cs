using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace E_Commerce.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Create(Category category)
        {
          await  _context.categories.AddAsync(category);
          await _context.SaveChangesAsync();

        }

        public async Task Delete(Category category)
        {
            _context.categories.Remove(category);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Getall()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetbyId(int id)
        {
            return await _context.categories.SingleOrDefaultAsync(c=> c.Id == id);
        }

        public async Task Update(Category category)
        {
             _context.categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}