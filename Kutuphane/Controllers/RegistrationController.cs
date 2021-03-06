using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        // GET: Registration
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Members member)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            member.Image= "https://i.hizliresim.com/m7hjvhh.jpg";
            member.School = "Okul bilgisi bulunmamaktadır.";
            kutuphaneEntities.Members.Add(member);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Login","Login");
        }
    }
}