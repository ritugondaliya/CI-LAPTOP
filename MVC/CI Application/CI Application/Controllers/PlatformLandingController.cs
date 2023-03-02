using CI_Application.Entities.CIDbContext;
using CI_Application.Entities.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace CI_Application.Controllers
{
    public class PlatformLandingController : Controller
    {

        private readonly CiPlatformContext _CiPlatformContext;

        public PlatformLandingController(CiPlatformContext CiPlatformContext)
        {
            _CiPlatformContext = CiPlatformContext;


        }

        public IActionResult PlatformLanding()
        {

            var usrid = HttpContext.Session.GetString("userID");
            if (usrid == null)
            {
                return RedirectToAction("Login", "Login");

            }

            //List<Mission> mission = _CiPlatformContext.Missions.ToList();
            List<Mission> mission = _CiPlatformContext.Missions.ToList();
           return View(mission);
        }
    }
}
