using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admins admins)
        {
            var result = kutuphaneEntities.Admins.FirstOrDefault(p => p.Mail == admins.Mail && p.Password == admins.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Mail, false);
                Session["Mail"] = result.Mail.ToString();
                return RedirectToAction("Index", "Statistics");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }

    }
}