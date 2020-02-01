using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string For { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public bool Read { get; set; }
    }
}