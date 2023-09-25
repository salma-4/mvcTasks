using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Employee employee = db.Employees.Include(c=>c.Office).SingleOrDefault(c=>c.Id==id);
            if(employee == null)
                return Content("Error");
            else
                return View(employee);
        }
          public IActionResult addNew()
         {

           List<Office> office = db.Offices.ToList();
            ViewBag.Off = office;
            return View();
        }
        public IActionResult AddToDB(Employee employee) {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            Employee emp = db.Employees.SingleOrDefault(n => n.Id== id);
            ViewBag.Employee = db.Employees.ToList();
            return View("Edit",emp);
        }
        public IActionResult EditInDB(Employee employee)
        {
            Employee oldEmp = db.Employees.SingleOrDefault(n=>n.Id== employee.Id);
            oldEmp.Name= employee.Name;
            oldEmp.Address= employee.Address;
            oldEmp.Age= employee.Age;
            oldEmp.email = employee.email;
            oldEmp.Salary= employee.Salary;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id) {
            Employee employee = db.Employees.SingleOrDefault(n=>n.Id==id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
