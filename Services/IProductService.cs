using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface IProductService
    {
        Task Create(Product product);
        Task Delete(Product product);
        Task Upadte(Product product);
        Task<Product> GetById(int id);
        Task<bool> IsValidCategory(int id);
        Task<bool> IsValidStock(int id);
        Task<bool> IsValidOffer(int id);



        Task<IEnumerable<Product>> GetAll(int categoryId=0);

    }
}