using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BugTracker.Models;
using Microsoft.AspNet.Identity;


namespace BugTracker.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public void UpdateIssue(int id, Issue issue)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var issueInDb = _context.Issues.Single(i => i.Id == id);

            if (issueInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            issueInDb.Name = issue.Name;
            issueInDb.Type = issue.Type;

            _context.SaveChanges();
        }
    }
}
