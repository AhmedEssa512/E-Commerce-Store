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
    public class OrderController : Controller
    {
        

        private readonly IOrderService _service;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly ICartService _cartservice;
        private readonly IStockService _stockService;
        private readonly IProductService _productService;



        public OrderController(IOrderService service,UserManager<IdentityUser> usermanager,ICartService cartservice,IStockService stockService,IProductService productService)
        {
            _service = service;
            _usermanager = usermanager;
            _cartservice = cartservice;
            _stockService = stockService;
            _productService = productService;
        }

        public IActionResult Create()=> View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]OrderFormDto orderFormDto)
        {
            var userId = _usermanager.GetUserId(User);

            var cart =  _cartservice.Getall(userId);
            

            var orderdetails = new OrderDetail{
                Name = orderFormDto.Name,
                Address = orderFormDto.Address,
                phone = orderFormDto.Phone,
                OrderDate = DateTime.Now,
                UserId = userId,
                TotalAmount = 0
            };

           int id =  await _service.CreateDetails(orderdetails);

            foreach (var item in cart)
            {
            
                var order = new Order{
                    ProductId = item.ProductId,
                    OrderDetailId = id,
                    Quantity = item.Quantity,
                };

                await _service.CreateOrder(order);
                await _service.DecreaseStock(item.ProductId,item.Quantity);
            }



            return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult> MyOrders()
        {
            var userId = _usermanager.GetUserId(User);

            return View(await _service.MyOrders(userId));

        } 


        public async Task<IActionResult> Delete(int orderId)
        {

            var order = await _service.GetById(orderId);
             if(order is null)
              return BadRequest("Order not found");

              var orderItems = await _service.GetOrderItems(orderId);
            foreach (var item in orderItems)
            {
                await _service.IncreaseStock(item.ProductId,item.Quantity);
            }

              await _service.Delete(order);

            // handle stock (return quantity to stock again)
            



              return RedirectToAction(nameof(MyOrders));
        }
        
            
        
    }
}