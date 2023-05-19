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
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;


        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create([FromForm] ProductDto dto)
        {
            if(!ModelState.IsValid)
             return BadRequest(ModelState);

            if(! await _productservice.IsValidStock(dto.StockId))
              return BadRequest("Stock not found");

            if(! await _productservice.IsValidCategory(dto.CategoryId))
              return BadRequest("Category not found");

             if(! await _productservice.IsValidOffer(dto.OfferId))
              return BadRequest("Offer not found");
              
              

            using var  DataStream = new MemoryStream();

            await dto.Photo.CopyToAsync(DataStream); 

             var product = new Product{
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Photo = DataStream.ToArray(),
                categoryId = dto.CategoryId,
                OfferId = dto.OfferId,
                stockId = dto.StockId,
                Created_at = DateTime.Now
             };

             await _productservice.Create(product);


        return RedirectToAction("Index","Home");



        }


        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productservice.GetById(id);

            if(product is null)
             return BadRequest("product not found");

             await _productservice.Delete(product);

             return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Search(int id)
        {
            var product = await _productservice.GetById(id);
            if(product is null )
             return BadRequest("Product not found");

             return View(product);
        }

        public async Task<IActionResult> All(int categoryId = 0)
        {
            return View(await _productservice.GetAll(categoryId));
        }

        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productservice.GetById(id);
            if(product is null)
             return BadRequest("Product not found");

             return View(product);
        }


        [Authorize(Roles="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm]ProductFormDto productFormDto)
        {
         if(!ModelState.IsValid)
             return BadRequest(ModelState);

             var product = await _productservice.GetById(productFormDto.Id);

             if(productFormDto.Photo is not null)
             {
                using var  DataStream = new MemoryStream();

                await productFormDto.Photo.CopyToAsync(DataStream); 

                product.Photo = DataStream.ToArray();
             }




            if(! await _productservice.IsValidStock(productFormDto.stockId))
              return BadRequest("Stock not found");

            if(! await _productservice.IsValidCategory(productFormDto.categoryId))
              return BadRequest("Category not found");

             if(! await _productservice.IsValidOffer(productFormDto.OfferId))
              return BadRequest("Offer not found");




            product.Name = productFormDto.Name;
            product.Description = productFormDto.Description;
            product.categoryId = productFormDto.categoryId;
            product.OfferId = productFormDto.OfferId;
            product.stockId = productFormDto.stockId;
            product.Price = productFormDto.Price;

            await _productservice.Upadte(product);

            return RedirectToAction("Index","Home");

        }


        public async Task<IActionResult> Details(int productId)
        {
          var product = await _productservice.GetById(productId);

          if(product is null )
           return BadRequest("Product not found");

           return View(product);
        }




        
    }
}