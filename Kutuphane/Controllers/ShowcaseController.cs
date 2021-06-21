using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace Kutuphane.Controllers
{
    [AllowAnonymous]
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Books.ToList();
            var membersCount = kutuphaneEntities.Members.Count();
            ViewBag.MembersCount = membersCount;
            var bookscount = kutuphaneEntities.Books.Count();
            ViewBag.BooksCount = bookscount;
            var staffcount = kutuphaneEntities.Staff.Count();
            ViewBag.StaffCount = staffcount;
            return View(result);
        }

        public ActionResult Books(int page = 1)
        {
            var result = kutuphaneEntities.Books.ToList().ToPagedList(page, 6);
            var membersCount = kutuphaneEntities.Members.Count();
            ViewBag.MembersCount = membersCount;
            var bookscount = kutuphaneEntities.Books.Count();
            ViewBag.BooksCount = bookscount;
            var staffcount = kutuphaneEntities.Staff.Count();
            ViewBag.StaffCount = staffcount;
            return View(result);
        } 
    }
}