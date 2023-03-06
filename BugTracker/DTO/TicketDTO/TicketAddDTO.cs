using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Enums;
using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.UI.DTO.TicketDTO
{
    public class TicketAddDTO
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public SeverityOptions Severity { get; set; }
        public List<DeveloperCheckboxItem> AssignedDevs { get; set; }
        [Required]
        public TicketTypeOptions Type { get; set; }
        [Required]
        public StatusOptions Status { get; set; }
    }
}
