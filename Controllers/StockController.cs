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
    [Authorize]
    public class StockController : Controller
    {
        private readonly IStockService _service;


        public StockController(IStockService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]StockDto stockDto)
        {
            var stock = new Stock{
                Quantity = stockDto.Quantity,
                Created_at = DateTime.Now
            };
              var CreatedStock =  await _service.Create(stock);
               

              if(CreatedStock is null)
               return BadRequest("Crated stock id is null");

          return RedirectToAction(nameof(AllStock));
        }

        // public async Task<IActionResult> ProductStockId()
        // {
        //     var stock =  (Stock)ViewData["ProductStockId"];

        //     return View(stock);
        // }

        public async Task<IActionResult> AllStock()
        {
            return View(await _service.getall());
        }


        public async Task<IActionResult> Delete(int id)
        {
            var stock = await _service.GetbyId(id);
            if(stock is null)
             return BadRequest("Stock not found");

            await _service.Delete(stock);

            return RedirectToAction(nameof(AllStock));

        }

        public async Task<IActionResult> Edit(int id)
        {
          var stock = await  _service.GetbyId(id);
          if(stock is null )
           return BadRequest("stock not found");
            return View(stock);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit([FromForm]StockEditForm stockForm)
        {
            var stock = await _service.GetbyId(stockForm.Id);

             stock.Quantity = stockForm.Quantity;

             await _service.Update(stock);

             return RedirectToAction(nameof(AllStock));
        }

        
    }
}