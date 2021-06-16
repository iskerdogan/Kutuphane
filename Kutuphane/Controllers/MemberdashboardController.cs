using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class MemberdashboardController : Controller
    {
        // GET: Memberdashboard
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Home()
        {
            var mail = (string)Session["Mail"];
            var result = kutuphaneEntities.Members.FirstOrDefault(p => p.Mail == mail);
            return View(result);
        }

        [HttpPost]
        public ActionResult HomeProfile(Members members)
        {
            var mail = (string)Session["Mail"];
            var user = kutuphaneEntities.Members.FirstOrDefault(p => p.Mail == mail);
            user.Password = members.Password;
            user.Name = members.Name;
            user.Surname = members.Surname;
            user.UserName = members.UserName;
            user.School = members.School;
            user.Image = members.Image;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Home");

        }
    }
}