
using CI_Application.Entities.CIDbContext;
using CI_Application.Entities.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CI.Controllers
{
    public class UserController : Controller
    {
        private readonly CiPlatformContext _CiPlatformContext;

        public UserController(CiPlatformContext CiPlatformContext)
        {
            _CiPlatformContext = CiPlatformContext;
        }
        //public IActionResult Index()
        //{
        //    List<User> Users = _CiPlatformContext.Users.ToList();
        //    return View(Users);
        //}


        // get from frontend


        public IActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            
                var obj = _CiPlatformContext.Users.FirstOrDefault(u => u.Email == user.Email);

                if (obj == null)
                {
                    _CiPlatformContext.Users.Add(user);
                    _CiPlatformContext.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.RegError = "email already exist";

                }
            
            return View();
        }


    }
}


