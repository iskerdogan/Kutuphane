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
        public ActionResult Home()
        {
            var mail = (string)Session["Mail"];
            //var result = kutuphaneEntities.Members.FirstOrDefault(p => p.Mail == mail);
            var result = kutuphaneEntities.Notifications.ToList();
            var memberId = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.Id).FirstOrDefault();
            ViewBag.Mail = mail;
            ViewBag.Name = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.Name).FirstOrDefault();
            ViewBag.Surname = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.Surname).FirstOrDefault();
            ViewBag.UserName = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.UserName).FirstOrDefault();
            ViewBag.Image = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.Image).FirstOrDefault();
            ViewBag.School = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.School).FirstOrDefault();
            ViewBag.PhoneNumber = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.PhoneNumber).FirstOrDefault();
            ViewBag.BooksCount = kutuphaneEntities.Transactions.Where(p => p.MemberId == memberId).Count();
            ViewBag.MesssagesCount = kutuphaneEntities.Messages.Where(p => p.GetedByMember == mail).Count();
            ViewBag.NotificationsCount = kutuphaneEntities.Notifications.Count();

            return View(result);
        }

        [HttpPost]
        public ActionResult HomeProfile(Members members)
        {
            if (!ModelState.IsValid)
            {
                return View("Home");
            }
            var mail = (string)Session["Mail"];
            var user = kutuphaneEntities.Members.FirstOrDefault(p => p.Mail == mail);
            user.Password = members.Password;
            user.Name = members.Name;
            user.Surname = members.Surname;
            user.PhoneNumber = members.PhoneNumber;
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
            var result = kutuphaneEntities.Transactions.Where(p => p.MemberId == id).OrderByDescending(p => p.Id).ToList();
            return View(result);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var mail = (string)Session["Mail"];
            var memberId = kutuphaneEntities.Members.Where(p => p.Mail == mail).Select(p => p.Id).FirstOrDefault();
            var result = kutuphaneEntities.Members.Find(memberId);
            return PartialView("Partial2", result);
        }
    }
}