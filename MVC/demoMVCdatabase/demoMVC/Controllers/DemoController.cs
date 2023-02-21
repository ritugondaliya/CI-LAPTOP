using demoMVC.Entity.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace demoMVC.Controllers
{
    public class DemoController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public DemoController(EmployeeDbContext employeeDbContext)
        {
                _employeeDbContext= employeeDbContext;
        }
        public IActionResult Index()
        {
           List<Employee> Users = _employeeDbContext.Employees.ToList();
            return View(Users);

        }
    }
}
