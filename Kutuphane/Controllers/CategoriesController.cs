using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Categories.Where(p=>p.Active==true).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Categories categories)
        {
            kutuphaneEntities.Categories.Add(categories);
            kutuphaneEntities.SaveChanges();
            return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            var result = kutuphaneEntities.Categories.Find(id);
            //kutuphaneEntities.Categories.Remove(result);
            result.Active = false;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult FetchCategory(int id)
        {
            var result = kutuphaneEntities.Categories.Find(id);
            return View("FetchCategory", result);
        }

        public ActionResult CategoryUpdate(Categories categories)
        {
            var result = kutuphaneEntities.Categories.Find(categories.Id);
            result.Name = categories.Name;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}