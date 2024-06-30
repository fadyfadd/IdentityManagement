using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityManagement.DbContext;
using IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityManagement.Controllers
{
    public class UserController : Controller
    {

        private List<SelectListItem> getRoles()
        {
            SelectListItem user1 = new SelectListItem();
            user1.Value = "32cbd3aa-b85e-4dcb-b6f7-775eac73b3e5";
            user1.Text = "User";

            List<SelectListItem> list = new List<SelectListItem>();          
            list.Add(user1);
            return list;

        }

        [HttpGet]
        public ViewResult Register()
        {
            RegisterModel model = new RegisterModel();
            model.Roles = getRoles();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        { 
          
            model.Roles = getRoles();
            ApplicationUser user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };


            if (!ModelState.IsValid)
                return View(model);

            var result = await this._userManager.CreateAsync(user, "sc%em2Rf");

            if (result.Errors?.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.First().Description);
                return View(model);
            }

        }

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [HttpGet]
        public IActionResult Login()
        {    
            return View();
        }

        public UserController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            ApplicationUser? user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                this.ModelState.AddModelError("", "User Not Found");
                return View();
            }
            await this._signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");


        }
    }
}