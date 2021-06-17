using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"].ToString();
            var result = kutuphaneEntities.Messages.Where(p => p.GetedByMember == mail.ToString()).ToList();
            return View(result);
        }

        public ActionResult PostedMessage()
        {
            var mail = (string)Session["Mail"].ToString();
            var result = kutuphaneEntities.Messages.Where(p => p.PostedByMember == mail.ToString()).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Messages messages)
        {
            var mail = (string)Session["Mail"].ToString();
            messages.PostedByMember = mail.ToString();
            messages.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            kutuphaneEntities.Messages.Add(messages);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("PostedMessage");
        }

        
    }
}