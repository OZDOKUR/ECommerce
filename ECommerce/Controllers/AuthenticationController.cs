using Business.Conccrete;
using ECommerce.Models.AuthenticationModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
       

        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AnonymousOnly]
        public IActionResult Login()
        {
            return View();
        }
        [AnonymousOnly]
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userModel.Mail, userModel.Password, false, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(userModel.Mail);
                    if (user != null)
                    {
                        var roles = await _userManager.GetRolesAsync(user);


                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("AdminDashboard", "Admin");
                        }
                        else if (roles.Contains("Worker"))
                        {
                            return RedirectToAction("User", "AdminUser");
                        }
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Authentication");
                }
            }
            return View();
        }
        [AnonymousOnly]
        public IActionResult Register()
        {
            return View();
        }
        [AnonymousOnly]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Status = true,
                    Email = registerModel.Email,
                    PhoneNumber = registerModel.PhoneNumber,
                    UserName = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Authentication");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("HATA", item.Description);
                    }
                }
            
            return View(registerModel);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Authentication");
        }
    }
}
