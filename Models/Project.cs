using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Project
    {
        public Project()
        {
            this.Issues = new HashSet<Issue>();
            this.Users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Owner")]
        public string OwnerUserId { get; set; }

        public virtual ApplicationUser OwnerUser { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }


    }
}