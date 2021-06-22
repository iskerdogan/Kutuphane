using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using PagedList;

namespace Kutuphane.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index(string search, int page = 1)
        {
            var result = from c in kutuphaneEntities.Categories select c;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Name.Contains(search));
            }
            return View(result.Where(p => p.Active == true).ToList().ToPagedList(page, 16));
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Categories categories)
        {
            categories.Active = true;
            kutuphaneEntities.Categories.Add(categories);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
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