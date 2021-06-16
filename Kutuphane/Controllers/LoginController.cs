using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Members members)
        {
            var result = kutuphaneEntities.Members.FirstOrDefault(p => p.Mail == members.Mail && p.Password == members.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Mail, false);
                Session["Mail"] = result.Mail.ToString();
                Session["Name"] = result.Name.ToString();
                Session["Surname"] = result.Surname.ToString();
                Session["Image"] = result.Image.ToString();
                return RedirectToAction("Home", "Memberdashboard");
            }
            else
            {
                return View();
            }
            
        }
    }
}