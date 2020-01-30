using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTracker.Models;

namespace BugTracker.ViewModels
{
    public class ProjectsViewModel
    {
        public IEnumerable<Issue> Issues { get; set; }

        public Project Project { get; set; }

        public ApplicationUser User { get; set; }
    }
}   