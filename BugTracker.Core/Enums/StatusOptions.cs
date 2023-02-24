using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Enums
{
    public enum StatusOptions
    {
        New,
        Resolved,
        [EnumMember(Value = "In Progress")]
        InProgress
    }
}
