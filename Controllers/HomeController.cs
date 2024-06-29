using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityManagement.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityManagement.DbContext;


namespace Identity_Management.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController>? _logger;
    private UserManager<ApplicationUser> _userManager;


    public HomeController(UserManager<ApplicationUser> userManager) {
        this._userManager = userManager;
 
    }

    [HttpGet]
    public async Task<ViewResult>  Register() {
        ApplicationUser user = new ApplicationUser();
        user.UserName = "fadyfadd";
        
       
        //var h =    await this._userManager.CreateAsync(user , "sc%em2Rf");

        return View();
    }

    [HttpPost]
    public async Task<ViewResult>  Register(RegisterModel model) {
        ApplicationUser user = new ApplicationUser();
        user.UserName = "fadyfadd";
        
       
        //var h =    await this._userManager.CreateAsync(user , "sc%em2Rf");

        return View();
    }

    [HttpGet]
    public IActionResult Login() {
        return View();
    }


    [HttpPost]
    public async Task<ActionResult> Login(LoginModel model) {
 
        ApplicationUser? user =  await _userManager.FindByNameAsync(model.UserName);
        if (user == null) {
            this.ModelState.AddModelError("" , "User Not Found");
             return View();
        }
        return RedirectToAction("Index");

       
    }


 
    [HttpGet]     
    public IActionResult  Information() {
        return Ok("error");
    } 

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
