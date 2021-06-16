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
            var result = kutuphaneEntities.Messages.ToList();
            return View(result);
        }

        public ActionResult NewMessage()
        {
            return View();
        }
    }
}