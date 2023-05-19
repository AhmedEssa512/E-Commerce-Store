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
    public class CartController : Controller
    {
        private readonly ICartService _service;
        private readonly UserManager<IdentityUser> _usermanager;




        public CartController(ICartService service,UserManager<IdentityUser> usermanager)
        {
            _service = service;
            _usermanager = usermanager;
        }



        public IActionResult ShoppingCart()
        {
            var userId = _usermanager.GetUserId(User);

            return View(_service.Getall(userId));
        }

        public async Task<IActionResult> Delete(int cartId)
        {
            var cart = await _service.GetById(cartId);

            if(cart is null)
             return BadRequest("Not found cart");

            await _service.Delete(cart);

            return RedirectToAction(nameof(ShoppingCart));

        }

        



        public async Task<IActionResult> Edit(int cartId,int Quantity)
        {

           var cart = await _service.GetById(cartId);

           cart.Quantity = Quantity;

           await _service.Update(cart);

           return RedirectToAction(nameof(ShoppingCart));
            
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> AddToCart(int productId,int quantity)
         {
            var userId =  _usermanager.GetUserId(User);
            var ExistingCart =  await _service.GetUserCart(productId,userId);

            if(ExistingCart is null)
            {
                var cart = new Cart{
                    ProductId = productId,
                    Quantity = quantity,
                    UserId = userId
                };

              await  _service.Create(cart);
            }
            else{
                ExistingCart.Quantity += quantity;
                await _service.Update(ExistingCart);
            }

            return  RedirectToAction("Index","Home");
         }





       
    }
}