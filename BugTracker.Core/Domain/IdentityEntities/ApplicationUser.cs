using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Name { get; set; }

        [InverseProperty("Reporter")]
        public ICollection<Ticket> ReportedTickets { get; set; }

        [InverseProperty("AssignedDevs")]
        public ICollection<Ticket> AssignedInTickets { get; set; }
        [InverseProperty("AssignedDevs")]
        public ICollection<Project> Projects { get; set; }


    }
}
