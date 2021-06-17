using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult BooksAction()
        {
            var mail = (string)Session["Mail"];
            var id = kutuphaneEntities.Members.Where(p => p.Mail == mail.ToString()).Select(p => p.Id).FirstOrDefault();
            var result = kutuphaneEntities.Transactions.Where(p => p.MemberId == id).ToList();
            return View(result);
        }

        public ActionResult Notifications()
        {
            var result = kutuphaneEntities.Notifications.ToList();
            return View(result);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}