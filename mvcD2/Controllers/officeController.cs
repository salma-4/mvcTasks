using Microsoft.AspNetCore.Mvc;
using mvcD2.Models;

namespace mvcD2.Controllers
{
    public class officeController : Controller
    {
        private CompanyContext db;
        public officeController()
        {
            db = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<Office> office = db.Offices.ToList();

            return View(office);
        }
        public IActionResult Details(int id)
        {
            Office office  = db.Offices.Where(n=>n.Id== id).FirstOrDefault();   
            if (office == null)
                return Content("Error");
            else
                return View(office);
        }
        public IActionResult addNew()
        {

            List<Office> office = db.Offices.ToList();
            ViewBag.Off = office;
            return View();
        }
        public IActionResult AddToDB(Office off)
        {
            db.Offices.Add(off);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
           Office off= db.Offices.SingleOrDefault(n => n.Id == id);
           // ViewBag.Office = db.Offices.ToList();
            return View("Edit",off);
        }
        public IActionResult EditInDB(Office office)
        {
            Office oldOFF = db.Offices.SingleOrDefault(n => n.Id == office.Id);
            oldOFF.Name = office.Name;
            oldOFF.Location = office.Location;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
           Office off = db.Offices.SingleOrDefault(o => o.Id == id);
            var emp = db.Employees.SingleOrDefault(n=>n.office_id==id);
            if (emp == null)
            {
                db.Offices.Remove(off);
                db.SaveChanges();
            }
            else
            {
                emp.office_id = null;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
