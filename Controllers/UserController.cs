using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityManagement.DbContext;
using IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagement.Controllers
{

    public class UserController : Controller
    {

        [HttpGet]
        public async Task<ViewResult> Register()
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = "fadyfadd";
            //var h =    await this._userManager.CreateAsync(user , "sc%em2Rf");
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> Register(RegisterModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = "fadyfadd";
            //var h =    await this._userManager.CreateAsync(user , "sc%em2Rf");
            return View();
        }

        private UserManager<ApplicationUser> _userManager;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {

            ApplicationUser? user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                this.ModelState.AddModelError("", "User Not Found");
                return View();
            }
            return RedirectToAction("Index");


        }
    }
}