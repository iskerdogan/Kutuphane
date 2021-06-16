using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Staff.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult StaffAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StaffAdd(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View("StaffAdd");
            }
            kutuphaneEntities.Staff.Add(staff);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StaffDelete(int id)
        {
            var result = kutuphaneEntities.Staff.Find(id);
            kutuphaneEntities.Staff.Remove(result);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchStaff(int id)
        {
            var result = kutuphaneEntities.Staff.Find(id);
            return View("FetchStaff", result);
        }

        public ActionResult StaffUpdate(Staff staff)
        {
            var result = kutuphaneEntities.Staff.Find(staff.Id);
            result.NameSurname = staff.NameSurname;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}