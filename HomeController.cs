using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CafeManagement.Models;
using Microsoft.EntityFrameworkCore;
using CafeManagement.Data;

namespace CafeManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private object _context;
    private readonly CafeDbContext _context;

    public HomeController(ILogger<HomeController> logger, CafeDbContext context)
    {
        _logger = logger;
        _context = context;

    }
  
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }




    //public async Task<IActionResult> Menu()
    //{
    //    var products = await _context.Products
    //        .Include(p => p.Category)
    //        .Where(p => !p.IsDeleted && p.IsAvailable)
    //        .ToListAsync();

    //    return View(products);
    //}
    public async Task<IActionResult> Menu(int? categoryId)
    {
        ViewBag.Categories = await _context.Categories.ToListAsync();
        ViewBag.SelectedCategory = categoryId;

        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => !p.IsDeleted && p.IsAvailable);

        if (categoryId != null)
        {
            products = products.Where(p => p.CategoryId == categoryId);
        }

        return View(await products.ToListAsync());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
