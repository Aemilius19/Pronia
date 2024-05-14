using _14MayWebApp.Models;
using _14MayWebApp.VIewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _14MayWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinmanager;

        public AccountController(UserManager<User> usermanager,SignInManager<User> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User appUser = new User()
            {
                Name=register.Name,
                Email=register.Email,
                Surname=register.Surname,
                UserName=register.Username
            };
            var result=await _usermanager.CreateAsync(appUser,register.Password);
            if (!result.Succeeded) 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
                return View();
            }
            await _signinmanager.SignInAsync(appUser,false);
            return RedirectToAction("Index", "Home");
        }
    }
}
