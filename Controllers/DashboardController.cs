using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNet.Identity;

namespace BugTracker.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var allProjects = _context.Projects
                .Include(p => p.OwnerUser)
                .ToList();

            var projects = _context.Projects
                .Include(p => p.OwnerUser)
                .Where(p => p.OwnerUser.UserName == User.Identity.Name)
                .ToList();

            var notifications = _context.Notifications
                .Where(n => n.For == User.Identity.Name)
                .ToList();

            foreach (var project in allProjects)
            {
                if (this.IsUserOnProject(userId, project.Id))
                {
                    projects.Add(project);
                }
            }

            var issues = _context.Issues
                .Where(i => i.AssignedTo == User.Identity.Name)
                .Include(i => i.Project)
                .ToList();

            DashboardViewModel vm = new DashboardViewModel
            {
                Projects = projects,
                Issues = issues,
                Notifications = notifications
            };

            return View(vm);
        }

        public bool IsUserOnProject(string userId, int projectId)
        {
            var project = _context.Projects.Find(projectId);
            var flag = project.Users.Any(u => u.Id == userId);
            return (flag);

        }
    }
}