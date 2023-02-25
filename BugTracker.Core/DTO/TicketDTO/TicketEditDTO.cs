using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO.TicketDTO
{
    public class TicketEditDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public SeverityOptions? Severity { get; set; }
        [Required]
        public TicketTypeOptions? Type { get; set; }
        [Required]
        public StatusOptions? Status { get; set; }
    }
}
