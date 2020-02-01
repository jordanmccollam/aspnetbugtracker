using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTracker.Models;

namespace BugTracker.ViewModels
{
    public class ViewBaseModel
    {
        public IEnumerable<Notification> Notifications { get; set; }
    }
}