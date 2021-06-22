using Kutuphane.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize(Roles = "A")]
    public class SettingsController : Controller
    {
        // GET: Settings
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index(string search, int page = 1)
        {
            var result = from a in kutuphaneEntities.Admins select a;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Mail.Contains(search));
            }
            return View(result.ToList().ToPagedList(page, 4));
        }

        [HttpGet]
        public ActionResult NewAdmin()
        {
            var result = kutuphaneEntities.Admins.ToList();
            return View(result);
        }

        [HttpPost]
        public ActionResult NewAdmin(Admins admins)
        {
            kutuphaneEntities.Admins.Add(admins);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            var result = kutuphaneEntities.Admins.Find(id);
            kutuphaneEntities.Admins.Remove(result);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchAdmin(int id)
        {
            var result = kutuphaneEntities.Admins.Find(id);
            return View("FetchAdmin", result);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admins admins)
        {
            var result = kutuphaneEntities.Admins.Find(admins.Id);
            result.Mail = admins.Mail;
            result.Password = admins.Password;
            result.Authorize = admins.Authorize;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}