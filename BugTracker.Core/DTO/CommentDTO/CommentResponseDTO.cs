﻿using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO.CommentDTO
{
    public class CommentResponseDTO
    {
        public ApplicationUser? Commenter { get; set; }
        public string? CommentText { get; set; }
        public DateTime Date { get; set; }
    }
}
