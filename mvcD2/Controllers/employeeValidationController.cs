using Microsoft.AspNetCore.Mvc;
using mvcD2.Models;
using mvcD2.ViewModels;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcD2.Controllers
{
    public class employeeValidationController : Controller
    {
        private CompanyContext db;
        public employeeValidationController()
        {
            db = new CompanyContext();
        }
        // add employee with validation
        [HttpGet]
        public IActionResult Add()
        {
            employeeVM emp = new employeeVM()
            {
                offices = new SelectList(db.Offices,"Id","Name")
            };
            return View(emp);
        }

        [HttpPost]
        public IActionResult Add( employeeVM employee)
        {
            if(ModelState.IsValid)
            {
                Employee emp= new Employee()
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    password =employee.password,
                    Salary = employee.Salary,
                    email = employee.email,
                    office_id = employee.office_id,
                };
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index", "employee");
            }
            employee.offices = new SelectList(db.Offices, "Id", "Name");
                return View(employee);
           
        }
    }
}
