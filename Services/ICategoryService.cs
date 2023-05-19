using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface ICategoryService
    {
        Task  Create(Category category);
        Task Delete(Category category);
        Task<Category> GetbyId(int id);
        Task Update(Category category);
        Task<IEnumerable<Category>> Getall();

    }
}