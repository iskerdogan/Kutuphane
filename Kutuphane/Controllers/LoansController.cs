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
        public ActionResult ToLend()
        {
            List<SelectListItem> result1 = (from x in kutuphaneEntities.Members.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.Members = result1;
            List<SelectListItem> result2 = (from x in kutuphaneEntities.Books.Where(p=>p.Active == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.Books = result2;
            List<SelectListItem> result3 = (from x in kutuphaneEntities.Staff.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.NameSurname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.Staff = result3;

            return View();
        }

        [HttpPost]
        public ActionResult ToLend(Transactions transactions)
        {
            transactions.Members = kutuphaneEntities.Members.Where(p => p.Id == transactions.Members.Id).FirstOrDefault();
            transactions.Books = kutuphaneEntities.Books.Where(p => p.Id == transactions.Books.Id).FirstOrDefault();
            transactions.Staff = kutuphaneEntities.Staff.Where(p => p.Id == transactions.Staff.Id).FirstOrDefault();
            kutuphaneEntities.Transactions.Add(transactions);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
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