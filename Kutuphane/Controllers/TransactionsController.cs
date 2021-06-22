using Kutuphane.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index(string search, int page = 1)
        {
            var result = from t in kutuphaneEntities.Transactions select t;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Members.Name.Contains(search));
            }
            return View(result.Where(p => p.Status == true).OrderByDescending(p => p.Id).ToList().ToPagedList(page, 16));
        }
    }
}