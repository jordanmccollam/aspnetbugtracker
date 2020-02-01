using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;

namespace BugTracker.Controllers
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var notifications = _context.Notifications
                .Where(n => n.For == User.Identity.Name)
                .ToList();

            return View(notifications);
        }

        [Authorize]
        public ActionResult Read(int id)
        {
            var notification = _context.Notifications.Single(n => n.Id == id);

            _context.Notifications.Remove(notification);

            _context.SaveChanges();

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult Navbar()
        {
            var notifications = _context.Notifications
                .Where(n => n.For == User.Identity.Name);

            return PartialView("_LoginPartial", notifications);
        }

        public ActionResult SideMenu()
        {
            var notifications = _context.Notifications
                .Where(n => n.For == User.Identity.Name);

            return PartialView("_SideMenuPartial", notifications);
        }
    }
}