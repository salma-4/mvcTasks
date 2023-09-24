using Microsoft.AspNetCore.Mvc;
using mvcD2.Models;

namespace mvcD2.Controllers
{
    public class employeeController : Controller
    {

        private CompanyContext db;
       public employeeController()
        {
            db = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees= db.Employees.ToList();

            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee =db.Employees.Where(n=>n.Id== id).FirstOrDefault();
            if(employee == null)
                return Content("Error");
            else
                return View(employee);
        }
          public IActionResult addNew()
         {
            return View(addNew);
        }
        public IActionResult AddToDB(Employee employee) {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
