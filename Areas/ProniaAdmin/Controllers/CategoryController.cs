using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWeb.DAL;
using ProniaWeb.Models;

namespace ProniaWeb.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class CategoryController : Controller
    {
        
        
        AppDbContext _context;
        public CategoryController(AppDbContext context)
            {
                _context = context;
            }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.Include(x => x.Products).ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category=_context.Categories.FirstOrDefault(x=>x.Id==id);
            if(category != null) 
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var category=_context.Categories.FirstOrDefault(y=>y.Id==id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            var oldcategory= _context.Categories.FirstOrDefault(y => y.Id == category.Id);
            oldcategory.Name=category.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
