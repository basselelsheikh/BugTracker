using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Enums;
using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Core.DTO.TicketDTO
{
    public class TicketAddDTO
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public SeverityOptions Severity { get; set; }
        [Required]
        public TicketTypeOptions? Type { get; set; }
    }
}
