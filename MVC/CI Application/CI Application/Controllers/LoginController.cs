using System.Security.Claims;
using CI.Models;
using CI_Application.Controllers;
using CI_Application.Entities.CIDbContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LoginController : Controller
{
    private readonly CiPlatformContext _CiPlatformContext;

    public LoginController(CiPlatformContext CiPlatformContext)
    {
        _CiPlatformContext = CiPlatformContext;


    }



    [AllowAnonymous]
    public IActionResult Login(string returnUrl = "")
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login model)
    {
        if (ModelState.IsValid)
        {
            var user = await _CiPlatformContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {

                return RedirectToAction(nameof(HomeController.PlatFormLandingPage), "Home");
            }
            else
            {
                return RedirectToAction(nameof(LoginController.Login), "Home");
                //return View(model);
            }
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}