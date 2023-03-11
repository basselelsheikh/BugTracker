using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Domain.IdentityEntities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
