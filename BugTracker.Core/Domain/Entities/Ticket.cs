using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Bug domain model class
    /// </summary>
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public ApplicationUser Reporter { get; set; }
        public ICollection<ApplicationUser> AssignedDevs { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Reported { get; set; }
        public Project Project { get; set; }




    }
}
