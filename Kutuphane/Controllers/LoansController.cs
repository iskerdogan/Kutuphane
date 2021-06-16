using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class LoansController : Controller
    {
        // GET: Loans
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Transactions.Where(p => p.Status == false).ToList();
            return View(result);
        }

        [HttpGet]
        public  ActionResult ToLend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ToLend(Transactions transactions)
        {
            kutuphaneEntities.Transactions.Add(transactions);
            kutuphaneEntities.SaveChanges();
            return View();
        }

        public ActionResult LoanReturn(Transactions transactions)
        {

            var result = kutuphaneEntities.Transactions.Find(transactions.Id);
            DateTime date1 = DateTime.Parse(result.ReturnDate.ToString());
            DateTime date2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan date3 = date2 - date1;
            ViewBag.toValue = date3.TotalDays;
            return View("LoanReturn", result);
        }

        public ActionResult LoanReturnUpdate(Transactions transactions)
        {
            var result = kutuphaneEntities.Transactions.Find(transactions.Id);
            result.MemberReturnDate = transactions.MemberReturnDate;
            result.Status = true;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}