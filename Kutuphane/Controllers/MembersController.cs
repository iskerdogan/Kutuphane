using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Kutuphane.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index(string search,int page=1)
        {
            var result = from m in kutuphaneEntities.Members select m;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Name.Contains(search));
            }
            return View(result.ToList().ToPagedList(page, 8));
        }

        [HttpGet]
        public ActionResult MembersAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MembersAdd(Members members)
        {
            if (!ModelState.IsValid)
            {
                return View("MembersAdd");
            }
            kutuphaneEntities.Members.Add(members);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MembersDelete(int id)
        {
            var result = kutuphaneEntities.Members.Find(id);
            kutuphaneEntities.Members.Remove(result);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchMembers(int id)
        {
            var result = kutuphaneEntities.Members.Find(id);
            return View("FetchMembers", result);
        }

        public ActionResult MembersUpdate(Members members)
        {
            var result = kutuphaneEntities.Members.Find(members.Id);
            result.Name = members.Name;
            result.Surname = members.Surname;
            result.Mail = members.Mail;
            result.UserName = members.UserName;
            result.Password = members.Password;
            result.PhoneNumber = members.PhoneNumber;
            result.School = members.School;
            result.Image = members.Image;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BookHistory(int id)
        {
            var result = kutuphaneEntities.Transactions.Where(p => p.MemberId == id).ToList();
            var memberName = kutuphaneEntities.Members.Where(p => p.Id == id).Select(p => p.Name + " " + p.Surname).FirstOrDefault();
            ViewBag.NameSurname = memberName;
            return View(result);
        }
    }
}