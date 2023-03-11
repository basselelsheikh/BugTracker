using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Domain.Entities
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public List<ApplicationUser> Members { get; set; }
    }
}
