using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly IProductService _ProductService;

    public HomeController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }

    public async Task<IActionResult> Index(int categoryId=0)
    {
        return View(await _ProductService.GetAll(categoryId));
    }



   [Authorize(Roles = "Admin")]
    public IActionResult settings()
    {
        return View();
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

}
