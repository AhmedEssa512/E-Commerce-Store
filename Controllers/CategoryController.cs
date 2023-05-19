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
    [Authorize (Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;    
        }


        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]CategoryDto categoryDto)
        {
            if(!ModelState.IsValid)
             return BadRequest("Error in model state");

             var category = new Category{
                Name = categoryDto.name,
                Description = categoryDto.Description
             };

             await _service.Create(category);

             return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.GetbyId(id);
            if(category is null)
             return BadRequest("Category not found");

             await _service.Delete(category);

             return RedirectToAction(nameof(All)); 
        }



        public async Task<IActionResult> Edit(int id)
        {
            var category = await _service.GetbyId(id);

            if(category is null)
             return BadRequest("Category Not found");

             return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm]Category _categoryForm)
        {
            var category = await _service.GetbyId(_categoryForm.Id);
         

             category.Name = _categoryForm.Name;
             category.Description = _categoryForm.Description;

             await _service.Update(category);

           return RedirectToAction(nameof(All));

        }

        public async Task<IActionResult>All()
        {
            return View(await _service.Getall());
        }

        


    }
}