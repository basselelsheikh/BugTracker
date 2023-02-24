using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Enums
{
    public enum TicketTypeOptions
    {
        Bug,
        [EnumMember(Value = "Feature Request")]
        FeatureRequest,
        Issue
    }
}
