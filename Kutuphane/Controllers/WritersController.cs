using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class WritersController : Controller
    {
        // GET: Writers,
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Writers.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterAdd(Writers writers)
        {
            if (!ModelState.IsValid)
            {
                return View("WriterAdd");
            }
            kutuphaneEntities.Writers.Add(writers);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult WriterDelete(int id)
        {
            var result = kutuphaneEntities.Writers.Find(id);
            kutuphaneEntities.Writers.Remove(result);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchWriter(int id)
        {
            var result = kutuphaneEntities.Writers.Find(id);
            return View("FetchWriter", result);
        }

        public ActionResult WriterUpdate(Writers writers)
        {
            var result = kutuphaneEntities.Writers.Find(writers.Id);
            result.Name = writers.Name;
            result.Surname = writers.Surname;
            result.Detail = writers.Detail;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}