using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Classes;

namespace Kutuphane.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();


        [HttpGet]
        public ActionResult Index()
        {
            Class1 class1 = new Class1();
            class1.TableBook = kutuphaneEntities.Books.ToList();
            class1.TableAbout = kutuphaneEntities.About.ToList();
            return View(class1);
        }

        [HttpPost]
        public ActionResult Index(Contacts contacts)
        {
            kutuphaneEntities.Contacts.Add(contacts);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}