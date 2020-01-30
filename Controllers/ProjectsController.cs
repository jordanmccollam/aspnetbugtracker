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
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /Projects
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

            foreach (var project in allProjects)
            {
                if (this.IsUserOnProject(userId, project.Id))
                {
                    projects.Add(project);
                }
            }

            return View(projects);
        }

        // GET: /Projects/Details/:id
        public ActionResult Details(int id)
        {
            var issues = _context.Issues
                .Include(i => i.Project)
                .Where(i => i.ProjectId == id)
                .ToList();

            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            ProjectsViewModel vm = new ProjectsViewModel
            {
                Issues = issues,
                Project = project
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(Project project)
        {
            if (!ModelState.IsValid)
                return Redirect("Home");

            project.OwnerUserId = User.Identity.GetUserId();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return Redirect("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIssue(Issue issue)
        {
            if (!ModelState.IsValid)
                return Redirect("Home");

            if (issue.AssignedTo != null)
            {
                var project = _context.Projects
                    .Single(p => p.Id == issue.ProjectId);

                var user = _context.Users
                    .SingleOrDefault(u => u.UserName == issue.AssignedTo);

                if (project.OwnerUser.UserName != issue.AssignedTo)
                    project.Users.Add(user);
            }

            issue.OwnerUserId = User.Identity.GetUserId();

            _context.Issues.Add(issue);
            _context.SaveChanges();


            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPut]
        public ActionResult EditProject(Project project)
        {
            var projectInDb = _context.Projects.Single(p => p.Id == project.Id);

            if (ModelState.IsValid)
            {
                projectInDb.Name = project.Name;
                _context.SaveChanges();
            };

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPut]
        public ActionResult AddUser(string userToAdd, int id)
        {

            if (ModelState.IsValid)
            {
                var userInDb = _context.Users
                .SingleOrDefault(u => u.UserName == userToAdd);

                _context.Projects
                    .SingleOrDefault(p => p.Id == id)
                    .Users.Add(userInDb);

                _context.SaveChanges();
            };

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPut]
        public ActionResult EditIssue(string type, int id, string assignedTo)
        {

            if (ModelState.IsValid)
            {
                var issueInDb = _context.Issues.Single(i => i.Id == id);

                issueInDb.Type = type;

                issueInDb.AssignedTo = assignedTo;

                _context.SaveChanges();
            };

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpDelete]
        public ActionResult DeleteProject(int id)
        {

            var project = _context.Projects
                .Single(p => p.Id == id);

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Redirect("Index");
        }

        [HttpDelete]
        public ActionResult DeleteIssue(int id)
        {

            var issue = _context.Issues
                .Single(p => p.Id == id);

            _context.Issues.Remove(issue);
            _context.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPut]
        public ActionResult RemoveUser(string userToRemove, int id)
        {

            if (ModelState.IsValid)
            {
                var userInDb = _context.Users
                .SingleOrDefault(u => u.UserName == userToRemove);

                var projectIssues = _context.Issues
                    .Where(i => i.ProjectId == id)
                    .ToList();

                var issuesToEdit = projectIssues.Where(i => i.AssignedTo == userToRemove).ToList();

                issuesToEdit.ForEach(i => i.AssignedTo = null);

                _context.Projects
                    .SingleOrDefault(p => p.Id == id)
                    .Users.Remove(userInDb);

                _context.SaveChanges();
            };

            return Redirect(Request.UrlReferrer.ToString());
        }

        public bool IsUserOnProject(string userId, int projectId)
        {
            var project = _context.Projects.Find(projectId);
            var flag = project.Users.Any(u => u.Id == userId);

            return (flag);
        }
    }
}