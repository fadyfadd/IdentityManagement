using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;
using IdentityManagement.DbContext;
using Microsoft.AspNetCore.Authorization;


namespace IdentityManagement.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController>? _logger;
    private UserManager<ApplicationUser> _userManager;
    public HomeController(UserManager<ApplicationUser> userManager)
    {
        this._userManager = userManager;
    }

    [HttpGet]
    public IActionResult Information()
    {
        return Ok("error");
    }

    [Authorize()]
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
