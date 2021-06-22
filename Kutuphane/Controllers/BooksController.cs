using Kutuphane.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index(string search,int page=1)
        {
            var result = from k in kutuphaneEntities.Books select k;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Name.Contains(search));
            }
            //var result = kutuphaneEntities.Books.ToList();
            return View(result.ToList().ToPagedList(page, 8));
        }

        [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> category = (from i in kutuphaneEntities.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.result = category;
            List<SelectListItem> writer = (from i in kutuphaneEntities.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.result2 = writer;
            return View();
        }

        [HttpPost]
        public ActionResult BookAdd(Books books)
        {
            var category = kutuphaneEntities.Categories.Where(p => p.Id == books.Categories.Id).FirstOrDefault();
            var writer = kutuphaneEntities.Writers.Where(p => p.Id == books.Writers.Id).FirstOrDefault();
            books.Categories = category;
            books.Writers = writer;
            kutuphaneEntities.Books.Add(books);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BookDelete(int id)
        {
            var result = kutuphaneEntities.Books.Find(id);
            kutuphaneEntities.Books.Remove(result);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchBook(int id)
        {
            var result = kutuphaneEntities.Books.Find(id);
            List<SelectListItem> category = (from i in kutuphaneEntities.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.result = category;
            List<SelectListItem> writer = (from i in kutuphaneEntities.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.result2 = writer;
            return View("FetchBook", result);
        }
        public ActionResult BookUpdate(Books books)
        {
            var result = kutuphaneEntities.Books.Find(books.Id);
            result.Name = books.Name;
            result.Year = books.Year;
            result.NumberOfPages = books.NumberOfPages;
            result.Image = books.Image;
            result.Publisher = books.Publisher;
            result.Active = books.Active;
            var category = kutuphaneEntities.Categories.Where(p => p.Id == books.Categories.Id).FirstOrDefault();
            var write = kutuphaneEntities.Writers.Where(p => p.Id == books.Writers.Id).FirstOrDefault();
            result.CategoryId = category.Id;
            result.WriterId = write.Id;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}