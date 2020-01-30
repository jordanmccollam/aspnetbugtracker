using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Type { get; set; }

        public string Description { get; set; }

        [Display(Name = "Assign To")]
        public string AssignedTo { get; set; }

        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Display(Name = "Owner")]
        public string OwnerUserId { get; set; }
        public virtual ApplicationUser OwnerUser { get; set; }
    }
}