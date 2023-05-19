using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface IOfferService
    {
        Task Create(Offer offer);
        Task Delete(Offer offer);
        Task<Offer> GetById(int id);
        Task<IEnumerable<Offer>> GetAll();

        Task Update(Offer offer);




    }
}