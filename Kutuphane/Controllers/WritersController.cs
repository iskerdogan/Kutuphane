using Kutuphane.Models.Entity;
using PagedList;
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
        public ActionResult Index(string search,int page=1)
        {
            var result = from w in kutuphaneEntities.Writers select w;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Name.Contains(search));
            }
            return View(result.ToList().ToPagedList(page, 16));
        }

        [HttpGet]
        public ActionResult WriterAdd()
        {
            var result = kutuphaneEntities.Writers.ToList();
            return View(result);
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

        public ActionResult WriterBooks(int id)
        {
            var result = kutuphaneEntities.Books.Where(p => p.WriterId == id).ToList();
            var writerName = kutuphaneEntities.Writers.Where(p => p.Id == id).Select(p => p.Name + " " + p.Surname).FirstOrDefault();
            ViewBag.NameSurname = writerName;
            return View(result);
        }
    }
}