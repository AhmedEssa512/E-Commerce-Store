using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface IStockService
    {
        Task<Stock> Create(Stock stock);
        Task Delete(Stock stock);
        Task Update(Stock stock);
        Task<Stock> GetbyId(int stockId);
        Task<IEnumerable<Stock>> getall();

    }
}