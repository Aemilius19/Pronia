using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWeb.DAL;
using ProniaWeb.Models;
using System.Diagnostics;

namespace ProniaWeb.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products= await _context.Products.Include(x=>x.Category).ToListAsync();

            
            return View(products);
        }

        public async Task<IActionResult> ShopD()
        {
            return View();
        }
        public async Task<IActionResult> ShopV(int id)
        {
            var product= await _context.Products.Include(x=>x.Category).FirstOrDefaultAsync(x=>x.Id==id);
            ViewBag.Related =_context.Products.Where(x => x.CategoryId == product.CategoryId && x.Id != product.Id).ToList();
            return View(product);
        }
        public async Task<IActionResult> HomeTwo()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            return View();
        }

    }
}
