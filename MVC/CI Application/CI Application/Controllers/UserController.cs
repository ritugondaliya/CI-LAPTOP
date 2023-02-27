
using CI_Application.Entities.CIDbContext;
using CI_Application.Entities.DataModels;
using Microsoft.AspNetCore.Mvc;


namespace CI.Controllers
{
    public class UserController : Controller
    {

        private readonly CiPlatformContext _CiPlatformContext;

        public UserController(CiPlatformContext CiPlatformContext)
        {
            _CiPlatformContext = CiPlatformContext;


        }
        public IActionResult Index()
        {
            List<User> Users = _CiPlatformContext.Users.ToList();
            return View(Users);
        }


        // get from frontend
        public IActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]

        // push into database
        public IActionResult Create(User user)
        {
            _CiPlatformContext.Users.Add(user);
            _CiPlatformContext.SaveChanges();
            return RedirectToAction("Login", "Home");
        }


    }
}


