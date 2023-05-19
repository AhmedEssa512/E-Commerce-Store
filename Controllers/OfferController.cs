using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles ="Admin")]
    public class OfferController : Controller
    {
        private readonly IOfferService _service;

        public OfferController(IOfferService service)
        {
            _service = service;
        }


        
    public IActionResult Create()
    {
        return View();
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]OfferDto offerDto)
        {
            var offer = new Offer{
                Name = offerDto.Name,
                Description = offerDto.Description,
                Offer_percent = offerDto.Offer_percent,
                Active = offerDto.Active,
                Created_at = DateTime.Now
            };

            await _service.Create(offer);

            return RedirectToAction(nameof(All));
        }



        public async Task<IActionResult> Delete(int id)
        {
            var offer = await _service.GetById(id);
            if(offer is null)
             return BadRequest("Offer not found");

             await _service.Delete(offer);

             return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult>Edit(int id)
        {
            var offer = await _service.GetById(id);

            if(offer is null)
             return BadRequest("Offer Not found");

             return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Offer _offerForm)
        {
            var offer = await _service.GetById(_offerForm.Id);

            offer.Name = _offerForm.Name;
            offer.Description = _offerForm.Description;
            offer.Active = _offerForm.Active;
            
           await _service.Update(offer);

           return RedirectToAction(nameof(All));

        }



















        public async Task<IActionResult> All()
        {
            return View(await _service.GetAll());
        }

    }
}