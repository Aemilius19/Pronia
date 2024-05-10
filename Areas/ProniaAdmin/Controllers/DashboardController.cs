using Microsoft.AspNetCore.Mvc;

namespace ProniaWeb.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class DashboardController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
