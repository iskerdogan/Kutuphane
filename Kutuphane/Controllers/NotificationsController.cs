using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: Notifications
        KutuphaneEntities kutuphaneEntities = new KutuphaneEntities();
        public ActionResult Index()
        {
            var result = kutuphaneEntities.Notifications.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult NewNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewNotification(Notifications notifications)
        {
            kutuphaneEntities.Notifications.Add(notifications);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotificationDelete(int id)
        {
            var result = kutuphaneEntities.Notifications.Find(id);
            kutuphaneEntities.Notifications.Remove(result);
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchNotification(int id)
        {
            var result = kutuphaneEntities.Notifications.Find(id);
            return View("FetchNotification", result);
        }
        public ActionResult NotificationUpdate(Notifications notifications)
        {
            var result = kutuphaneEntities.Notifications.Find(notifications.Id);
            result.Category = notifications.Category;
            result.NotificationContent = notifications.NotificationContent;
            result.Date = notifications.Date;
            kutuphaneEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotificationContent(int id)
        {
            var result = kutuphaneEntities.Notifications.Where(p => p.Id == id).ToList();
            return View(result);
        }

    }
}