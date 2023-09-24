using Microsoft.AspNetCore.Mvc;
using mvcDay1.Models;

namespace mvcDay1.Controllers
{
    public class aboutController : Controller
    {
       public ViewResult getData()
        {
            employeeModel emp = new employeeModel()
            {
                Id = 1,
                Name="salma",
                Address="cairo",
                Salary=9000.6,
                Department="HR"
            };
         return View("employee",emp);
        }
    }
}
