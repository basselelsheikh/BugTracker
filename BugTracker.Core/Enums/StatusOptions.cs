using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BugTracker.Core.Enums
{
    public enum StatusOptions
    {
        New,
        Resolved,
        [Display(Name = "In Progress")]
        InProgress
    }
}
