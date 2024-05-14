
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14MayWebApp.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
