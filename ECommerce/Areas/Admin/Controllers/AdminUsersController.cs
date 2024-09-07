using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Areas.Admin.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Areas.Admin.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminUsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var roles = await _roleManager.Roles.ToListAsync(); // Asenkron olarak roller alınıyor

            ViewBag.RoleOptions = roles.Select(role => new SelectListItem
            {
                Value = role.Name,
                Text = role.Name
            }).ToList();

            var model = new List<AdminUserVM>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var role = userRoles.FirstOrDefault();

                model.Add(new AdminUserVM
                {
                    Id = user.Id,
                    Name = user.FirstName,
                    LastName = user.LastName,
                    Mail = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = role
                });
            }

            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> Add(AdminUserVM model)
        {
            //Sonra Yapılacak

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminUserVM model)
        {
            //Sonra Yapılacak

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(string id)
        {
            //Sonra Yapılacak

            return RedirectToAction("Index");
        }
    }
}
