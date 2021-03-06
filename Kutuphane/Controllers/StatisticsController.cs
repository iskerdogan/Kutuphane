using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Members.Count();
            ViewBag.MembersCount = result;
            var result2 = kutuphaneEntities.Books.Count();
            ViewBag.BooksCount = result2;
            var result3 = kutuphaneEntities.Books.Where(p => p.Active == false).Count();
            ViewBag.LoansCount = result3;
            var result4 = kutuphaneEntities.Penalties.Sum(p => p.Debt);
            ViewBag.Money = result4;
            return View();
        }


        
    }
}